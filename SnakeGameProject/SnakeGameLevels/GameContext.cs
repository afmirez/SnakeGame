using SnakeGameProject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    public class GameContext
    {
        private ILevel _currentLevel;
        public string _currentLevelName;
        private Player _player;
        public Snake _snake;
        private Map _map;
        public int currentScore = 0;
        public int maxScore;
        GameLogic gameLogic;

        public event Action currentScoreChangeHandler;
        public event Action playerMaxScoreUpdateHandler;
        public event Action levelCompleteHandler;


        public GameContext(Player player)
        {
            _player = player;
            _map = new Map(13,38);
            _snake = new Snake(7, 14);
            maxScore = _player.MaxScore;
            _snake.SnakeDieHandler += OnSnakeDie;
            _snake.SnakeEatHandler += onSnakeEat;
            gameLogic = new GameLogic(_map, _snake);
            _currentLevel = new LevelOne(this, gameLogic);
            _currentLevelName = _currentLevel.Name;
        }
        
        public void OnSnakeDie()
        {

            int top = SnakeGameVisualRenders.GetMainBannerHeight() + SnakeGameVisualRenders.GetMapHeight() + 2;
            int padding = SnakeGameVisualRenders.GetMapPadding();
            Console.SetCursorPosition(padding, top + 1);
            Console.WriteLine($"\x1b[91mTHE SNAKE HAS DIED\x1b[39m");
            gameLogic.GameOver();
            Console.SetCursorPosition(padding, top + 2);
            Console.WriteLine($"\x1b[95mPress SPACE to go back or ENTER to restart\x1b[39m");


            SnakeGameOptions();
         
        }

        public void SetNewLevel(ILevel level)
        {
            _currentLevel.FinishLevel();
            //_snake.SnakeEatHandler -= onSnakeEat;
            gameLogic.GameOver();
            int top = SnakeGameVisualRenders.GetMainBannerHeight() + SnakeGameVisualRenders.GetMapHeight() + 2;
            int padding = SnakeGameVisualRenders.GetMapPadding();
            Console.SetCursorPosition(padding, top + 1);
            Console.WriteLine($"\x1b[94mTHE LEVEL HAS BEEN COMPLETED\x1b[39m");
            Console.SetCursorPosition(padding, top + 2);
            Console.WriteLine($"\x1b[95mPress SPACE to go back or ENTER to continue\x1b[39m");
            SnakeGameLevelOptions(level);
        }


        public void onLevelComplete()
        {
            // Esto sera usado para el RENDER, no para la logica
            levelCompleteHandler?.Invoke();
        }

        public void SnakeGameLevelOptions(ILevel NewLevel)
        {
            ConsoleKeyInfo selectedKey;
            do
            {
                selectedKey = Console.ReadKey(true);
            }
            while (selectedKey.Key != ConsoleKey.Spacebar &&
                   selectedKey.Key != ConsoleKey.Enter);

            if (selectedKey.Key == ConsoleKey.Spacebar)
            {
                _snake.SnakeDieHandler -= OnSnakeDie;
                _snake.SnakeEatHandler -= onSnakeEat;
                NewLevel.FinishLevel();
                _snake.Die();
                Console.Clear();
                SnakeGameVisualRenders.RenderAppBanner();
            }
            else if (selectedKey.Key == ConsoleKey.Enter)
            {
                _currentLevel = NewLevel;
                _currentLevelName = _currentLevel.Name;
                Console.Clear();
                _snake.RegenerateSnake();
                _currentLevel.StartLevel();
            }
        }


        public void SnakeGameOptions()
        {
            ConsoleKeyInfo selectedKey;
            do
            {
                selectedKey = Console.ReadKey(true);
            }
            while (selectedKey.Key != ConsoleKey.Spacebar &&
                   selectedKey.Key != ConsoleKey.Enter);

            if (selectedKey.Key == ConsoleKey.Spacebar)
            {
                _currentLevel.FinishLevel();
                _snake.SnakeDieHandler -= OnSnakeDie;
                _snake.SnakeEatHandler -= onSnakeEat;
                Console.Clear();
                SnakeGameVisualRenders.RenderAppBanner();
            }
            else if (selectedKey.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                RestartGame();
            }
        }

        public void initLevel()
        {
            _currentLevel.StartLevel();
        }


        public void RestartGame()
        {
            currentScore = 0;
            _snake.RegenerateSnake();
            gameLogic.RestartGame();
            maxScore = _player.MaxScore;
            gameLogic.MoveSnake(SnakeMovement.Right);
        }

        public void onSnakeEat()
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
    }
}