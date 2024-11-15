﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject.Core
{
    public class SnakeGame
    {
        public void StartGame()
        {
            Player? player = CreatePlayer();
            if (player == null)
            {
                Console.Clear();
                SnakeGameVisualRenders.RenderAppBanner();
                return;
            }
            GameContext gameContext = new GameContext(player);
            SnakeGameVisualRenders.SetGameContext(gameContext);
            SnakeGameVisualRenders.SuscribeToEvents();
            gameContext.InitLevel();
        }
        private Player? CreatePlayer()
        {
            Console.Clear();
            SnakeGameVisualRenders.RenderAppBanner();
            StringBuilder input = new StringBuilder();
            SnakeGameVisualRenders.RenderExitSpacebar();
            Console.Write("\n\n Who will control the snake? Enter your name (min. 3 characters): ");
            Player? player;
            string? userName = GetUserName();
            if (userName == null)
            {
                player = null;
                return player;
            }
            player = new Player(userName);
            return player;
        }
        private string? GetUserName()
        {
            StringBuilder userInput = new StringBuilder();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(intercept: true);

                    if (key.Key == ConsoleKey.Spacebar)
                    {
                        return null;
                    }

                    else if (key.Key == ConsoleKey.Enter)
                    {
                        if (userInput.Length >= 3)
                        {
                            return userInput.ToString();
                        }
                    }
                    else if (key.Key == ConsoleKey.Backspace)
                    {
                        if (userInput.Length > 0)
                        {
                            userInput.Remove(userInput.Length - 1, 1);
                            Console.Write("\b \b");
                        }
                    }
                    else
                    {
                        if (userInput.Length < 12)
                        {
                            Console.Write(key.KeyChar);
                            userInput.Append(key.KeyChar);
                        }
                    }
                }
            }
        }
    }
}