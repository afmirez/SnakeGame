using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    internal class SnakeGame
    {
        public SnakeGame() { }
        public void StartGame() {
            while (true) {
                Console.WriteLine("Welcome to the SNAKE GAME.");
                //CreatePlayer();
                Map map = new Map(15, 20);
                map.BuildWalls();
                MapPrinter printer = new MapPrinter();
                printer.PrintMap(map);
                Console.ReadLine();
            }
        }

        // Tal vez esto deba ser parte de Player Class
        public void CreatePlayer()
        {
            string usrInput = string.Empty;
            Regex regex = new Regex("^[a-zA-Z]+$");
             
            do
            {
                Console.WriteLine("Give me your name (letters only): ");
                usrInput = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(usrInput))
                {
                    Console.Clear();
                    Console.WriteLine("The name cannot be empty or contain only spaces. Please try again.");
                }
                else if (!regex.IsMatch(usrInput))
                {
                    Console.Clear();
                    Console.WriteLine("The name must contain only letters (a-z, A-Z). Please try again.");
                }
                else
                {
                    Player player = new Player(usrInput);

                }
            } while (string.IsNullOrWhiteSpace(usrInput) || !regex.IsMatch(usrInput));
        }
        public void IsGameOver()
        {

        }



    }
}