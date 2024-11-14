using SnakeGameProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    public class LevelOne : ILevel
    {

        GameContext _game;
        GameLogic _gameLogic;
        string levelGameName = "[LEVEL ONE -- GENESIS CRAWL]";
        int snakeSpeed = 50;
        int foodSpawnRate = 8000;
        int foodRemoveRate = 4000;
        int maxLevelScore = 3;

        public string Name => levelGameName;

        public LevelOne(GameContext game, GameLogic gameLogic)
        {
            _game = game;
            _gameLogic = gameLogic;
           
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
                _game.SetNewLevel(new LevelTwo(_game, _gameLogic));
            }

        }

        public void FinishLevel()
        {
            _game.currentScoreChangeHandler -= EndLevel;

        }
    }
}
