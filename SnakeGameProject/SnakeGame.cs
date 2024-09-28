using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    internal class SnakeGame
    {
        // Esta clase puede cargar el player
        // El mapa
        // La comida
        // Y arrancar el juego (niveles)

        public SnakeGame() { }
        public void StartGame()
        {
            Player player = CreatePlayer();

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
                        if (userInput.Length < 12) {
                            Console.Write(key.KeyChar);
                            userInput.Append(key.KeyChar);
                        }
                    }
                }
            }
        }
        public Player? CreatePlayer()
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
        public void LoadLevel(Player player)
        {
            GameContext game = new GameContext();
            // Initialize the game
            // Simulamos el bucle del juego
            //while (true)
            //{
            //    game.Update();  // Actualiza el nivel actual
            //    System.Threading.Thread.Sleep(1000);  // Simula el paso del tiempo (1 segundo)
            //    game.TimeSurvived++;  // Incrementa el tiempo que el jugador ha sobrevivido

            //    // Detener el bucle si el juego se completa
            //    if (game.TimeSurvived > 60)
            //        break;
            //}
        }
    }
}
