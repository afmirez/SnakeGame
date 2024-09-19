using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    public class Menu {
        private string[] _options;
        private IMenuStrategy _strategy;

        public Menu( string[] options, IMenuStrategy strategy) 
        {
            _strategy = strategy;
            _options = options;
        }

        public void ShowMenu()
        {
            while (true)
            {
                for (int i = 0; i < _options.Length; i++)
                {
                    Console.WriteLine($" {i + 1} - {_options[i]}");
                }
                this._strategy.ExecuteOptions();
            }
        }
    }
}