using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    internal class SnakeGame
    {
        public SnakeGame() { }
        public void StartGame()
        {
            CreatePlayer();

        }


        public void CreatePlayer()
        {
            Console.Write("Enter your name: ");
            string? name = Console.ReadLine();
            switch (name)
            {
                case null:
                    Console.WriteLine("Invalid name. Try again...");
                    CreatePlayer();
                    break;
                default:
                    Player player = new Player(name);
                    break;
            }
        }

        // TO-DO: 
        public void StopGame() {
            // Stop the game
        }

        // TO-DO:
        public void LoadUsersScores()
        {
            // Load the scores from the file
        }

    }
}
