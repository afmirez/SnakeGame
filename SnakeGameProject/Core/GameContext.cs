using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using SnakeGameProject.Entities;
using SnakeGameProject.VisualRenders;

namespace SnakeGameProject.Core
{
    public enum ContextActions
    {
        Restart,
        Continue
    }
    public class GameContext
    {
        private GameLogic _gameLogic;
        private ILevel _currentLevel;
        private Player _player;
        private Snake _snake;
        private Map _map;
        public string currentLevelName;
        public int currentScore;
        public int maxScore;

        public event Action currentScoreChangeHandler = delegate { };
        public event Action playerMaxScoreUpdateHandler = delegate { };
        public event Action levelCompleteHandler = delegate { };

        public GameContext(Player player)
        {
            _player = player;
            _map = new Map(13, 38);
            _snake = new Snake(7, 14);
            _gameLogic = new GameLogic(_map, _snake);
            _currentLevel = new LevelOne(this, _gameLogic);
            currentLevelName = _currentLevel.Name;
            maxScore = _player.MaxScore;
            currentScore = 0;
            _snake.SnakeDieHandler += OnSnakeDie;
            _snake.SnakeEatHandler += OnSnakeEat;
        }
        public void InitLevel()
        {
            _currentLevel.StartLevel();
        }
        private void OnLevelComplete()
        {
            levelCompleteHandler?.Invoke();
        }
        public void SetNewLevel(ILevel level)
        {
            _currentLevel.FinishLevel();
            _gameLogic.StopGame();
            ShowGameContextInfo("The level has been completed", ContextActions.Continue);
            ChangeLevelOptions(level);
        }
        private void ChangeLevelOptions(ILevel NewLevel)
        {
            if (HandleCommonOptions() == ConsoleKey.Enter)
            {
                _currentLevel = NewLevel;
                currentLevelName = _currentLevel.Name;
                Console.Clear();
                _snake.RegenerateSnake();
                _currentLevel.StartLevel();
            }
            else
            {
                NewLevel.FinishLevel();
                _snake.Die();
            }
        }
        private void OnSnakeEat()
        {
            if (_snake.isAlive)
            {
                currentScore = currentScore + 1;
                if (currentScore > maxScore)
                {
                    _player.UpdateMaxScore(currentScore);
                    maxScore = currentScore;
                    playerMaxScoreUpdateHandler?.Invoke();
                }
                currentScoreChangeHandler?.Invoke();
            }
        }
        private void OnSnakeDie()
        {
            _gameLogic.StopGame();
            ShowGameContextInfo("The snake has died", ContextActions.Restart);
            AfterDieOptions();
        }
        private void AfterDieOptions()
        {
            if (HandleCommonOptions() == ConsoleKey.Enter)
            {
                Console.Clear();
                ResetGame();
            }
            else
            {
                _currentLevel.FinishLevel();
            }
        }
        private void ResetGame()
        {
            currentScore = 0;
            maxScore = _player.MaxScore;
            _snake.RegenerateSnake();
            _gameLogic.RestartGame();
            _gameLogic.MoveSnake(SnakeMovement.Right);
        }
        private ConsoleKey HandleCommonOptions()
        {
            ConsoleKeyInfo selectedKey;
            do
            {
                selectedKey = Console.ReadKey(true);
            }
            while (selectedKey.Key != ConsoleKey.Spacebar && selectedKey.Key != ConsoleKey.Enter);

            if (selectedKey.Key == ConsoleKey.Spacebar)
            {
                _snake.SnakeDieHandler -= OnSnakeDie;
                _snake.SnakeEatHandler -= OnSnakeEat;
                Console.Clear();
                SnakeGameVisualRenders.RenderAppBanner();
            }
            return selectedKey.Key;
        }
        private void ShowGameContextInfo(string message, ContextActions action)
        {
            string asciiColor = action == ContextActions.Restart ? "\x1b[91m" : "\x1b[94m";
            string actionString = action == ContextActions.Restart ? "restart" : "continue";
            // 11-1-24 7:13 am : Habran cambios para obtener el top y padding
            int top = SnakeGameVisualRenders.GetMainBannerHeight() + SnakeGameVisualRenders.GetMapHeight() + 2;
            int padding = SnakeGameVisualRenders.GetMapPadding();
            Console.SetCursorPosition(padding, top + 1);
            Console.WriteLine($"{asciiColor}{message.ToUpper()}\x1b[39m");
            Console.SetCursorPosition(padding, top + 2);
            Console.WriteLine($"\x1b[95mPress SPACE to go back or ENTER to {action}\x1b[39m");
        }
    }
}