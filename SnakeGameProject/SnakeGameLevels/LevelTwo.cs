using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    public class LevelTwo : ILevel
    {
        GameContext _game;
        GameLogic _gameLogic;
        string levelGameName = "[LEVEL TWO -- VELOCITY RUSH]";
        int snakeSpeed = 30;
        int foodSpawnRate = 8000;
        int foodRemoveRate = 4000;
        int maxLevelScore = 100;

        public string Name => levelGameName;

        public LevelTwo(GameContext game, GameLogic gameLogic)
        {
            _game = game;
            _gameLogic = gameLogic;
            game.currentScoreChangeHandler += EndLevel;
        }

        public void StartLevel()
        {
            Console.Clear();
            _game.currentScoreChangeHandler += EndLevel;
            _gameLogic.SetSnakeLogicProperties(snakeSpeed, foodSpawnRate, foodRemoveRate);
            _gameLogic.InitGame();
            _gameLogic.MoveSnake(SnakeMovement.Right);
        }


        public void EndLevel()
        {
            if (_game.currentScore >= maxLevelScore)
            {
                Console.WriteLine("Holaa");
                //_game.SetLevel(new LevelTwo(_game, _gameLogic));
            }

        }

        public void FinishLevel()
        {
            _game.currentScoreChangeHandler -= EndLevel;
        }
    }
}
