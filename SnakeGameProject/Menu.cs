using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{

    public class Menu {


        public const string BANNER = "Welcome to the Snake Game!\n\n";
        private string[] options = ["Start Game", "Show Scoreboard", "Exit"];

        public Menu() 
        {

        }
        public void ShowMenu()
        {
            bool isRunning = true;
            Console.WriteLine(BANNER);

            while (isRunning)
            {
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($" {i + 1} - {options[i]}");
                }

                Console.Write("\nChoose an option: ");
                string? option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        SnakeGame game = new SnakeGame();
                        game.StartGame();
                        break;

                    case "2":
                        Console.WriteLine("Solution not implemented.");
                        // ShowScoreboard();
                        break;
                    case "3":
                        isRunning = false; // Finaliza el loop y sale del menú
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.Write("Invalid option. Try again...\n\n\n");
                        break;
                }
            }
        }

    }
}
