﻿using SnakeGameProject.Core;
using SnakeGameProject.Credits;

namespace SnakeGameProject
{
    internal class IMainMenuStrategy : IMenuStrategy
    {
        public void ExecuteOptions(int optionSelected)
        {
            switch (optionSelected)
            {
                case 1:
                    SnakeGame snakeGame = new SnakeGame();
                    snakeGame.StartGame();
                    break;
                case 2:
                    SnakeGameCredits.ShowCredits();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
