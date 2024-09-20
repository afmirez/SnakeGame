using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    public enum BackgroundColor {
        Black,
        White
    }

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
                        ResetColor(BackgroundColor.White);
                    }
                    else
                    {
                        prefix = " ";
                        ResetColor(BackgroundColor.Black);
                    }

                    Console.WriteLine($"{prefix} {_options[i]}");
                   
                }
                SelectOption();
            }
        }

        private void SelectOption()
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
                ResetColor(BackgroundColor.Black);
                _strategy.ExecuteOptions(selectedIndex + 1);
            }
            ResetColor(BackgroundColor.Black);
            Console.Clear();
        }
        private void ResetColor(BackgroundColor color)
        {
            if (color == BackgroundColor.Black)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (color == BackgroundColor.White)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
            }
        }
    }
}