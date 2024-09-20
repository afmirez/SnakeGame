using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    public class Menu 
    {
        private string[] _options;
        private IMenuStrategy _strategy;
        public int selectedIndex = 0;
        public Menu(string[] options, IMenuStrategy strategy)
        {
            _strategy = strategy;
            _options = options;
        }
        public void ShowMenu()
        {
            Console.CursorVisible = false;
            while (true)
            {
                SnakeGameVisualRenders.RenderAppBanner();
                for (int i = 0; i < _options.Length; i++)
                {
                    string currentOption = _options[i];
                    string prefix;

                    if (i == selectedIndex)
                    {
                        prefix = ">";
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        prefix = " ";
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine($"{prefix} {_options[i]}");
                   
                }
                SelectOption();
            }
        }

        public void SelectOption()
        {
            ConsoleKeyInfo selectedKey;
            do
            {
                selectedKey = Console.ReadKey(true);
            }
            while (selectedKey.Key != ConsoleKey.UpArrow &&
                   selectedKey.Key != ConsoleKey.DownArrow &&
                   selectedKey.Key != ConsoleKey.Enter);

            if (selectedKey.Key == ConsoleKey.DownArrow && selectedIndex < _options.Length - 1)
            {
                selectedIndex++;
            }
            else if (selectedKey.Key == ConsoleKey.UpArrow && selectedIndex > 0)
            {
                selectedIndex--;
            }
            else if (selectedKey.Key == ConsoleKey.Enter)
            {
                ResetColor();
                _strategy.ExecuteOptions(selectedIndex + 1);
            }
            ResetColor();
            Console.Clear();
        }
        public void ResetColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}