using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    internal class IMainMenuStrategy : IMenuStrategy
    {
        public void ExecuteOptions(int optionSelected)
        {
            //Console.Write("\nChoose an option: ");
            //string? option = Console.ReadLine();

            switch (optionSelected)
            {
                case 1:
                    SnakeGame game = new SnakeGame();
                    game.StartGame();
                    break;
                case 2:
                    Console.WriteLine("Showing Credits.");
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                //default:
                //    Console.Clear();
                //    Console.Write("Invalid option. Try again...\n\n\n");
                //    break;
            }
        }
    }
}
