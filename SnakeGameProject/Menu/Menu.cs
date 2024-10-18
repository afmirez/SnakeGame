using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public int previousIndex = 0;
        public int _topSpace;
        public Menu(string[] options, IMenuStrategy strategy, int? topSpace)
        {

            _strategy = strategy;
            _options = options;
            _topSpace = topSpace ?? 0;
        }
        public void ShowMenu()
        {
            Console.CursorVisible = false;
            RenderMenu();
            while (true)
            {
                RenderMenu();
                SelectOption();
            }
        }
        private void RenderMenu()
        {
            for (int i = 0; i < _options.Length; i++) {
                string currentOption = _options[i];
                if (i == selectedIndex)
                {
                    HighlightOption(true, currentOption);
                } else
                {
                    HighlightOption(false, currentOption);
                }
            }
        }
        private void UpdateOption(int index, bool isSelected)
        {
            Console.SetCursorPosition(0, index);
            HighlightOption(isSelected, _options[index]);
        }
        private void HighlightOption(bool isOptionSelected, string option)
        {
            int optionIndex = Array.IndexOf(_options, option);

            /*Set the cursor position at the beginning of the line, 
               adjusted by the height of the banner and the option's index*/
            Console.SetCursorPosition(0, _topSpace + optionIndex);

            string prefix = isOptionSelected ? "> " : "  ";

            if (isOptionSelected)
            {
                ResetColor(BackgroundColor.White);
            }
            else
            {
                ResetColor(BackgroundColor.Black);
            }

            Console.WriteLine(prefix + option);
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

            previousIndex = selectedIndex;

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
                return;
            }
            UpdateOption(previousIndex, false);
            UpdateOption(selectedIndex, true);
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