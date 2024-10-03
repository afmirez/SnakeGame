using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{

    public static class SnakeGameVisualRenders
    {
        public static void RenderAppBanner()
        {
            SetForeGroundColor(ForeGroundColors.Green);
            const string mainBanner = " $$$$$$\\                      $$\\                        $$$$$$\\                                    \r\n" +
                         "$$  __$$\\                     $$ |                      $$  __$$\\                                   \r\n" +
                         "$$ /  \\__|$$$$$$$\\   $$$$$$\\  $$ |  $$\\  $$$$$$\\        $$ /  \\__| $$$$$$\\  $$$$$$\\$$$$\\   $$$$$$\\  \r\n" +
                         "\\$$$$$$\\  $$  __$$\\  \\____$$\\ $$ | $$  |$$  __$$\\       $$ |$$$$\\  \\____$$\\ $$  _$$  _$$\\ $$  __$$\\ \r\n" +
                         " \\____$$\\ $$ |  $$ | $$$$$$$ |$$$$$$  / $$$$$$$$ |      $$ |\\_$$ | $$$$$$$ |$$ / $$ / $$ |$$$$$$$$ |\r\n" +
                         "$$\\   $$ |$$ |  $$ |$$  __$$ |$$  _$$<  $$   ____|      $$ |  $$ |$$  __$$ |$$ | $$ | $$ |$$   ____|\r\n" +
                         "\\$$$$$$  |$$ |  $$ |\\$$$$$$$ |$$ | \\$$\\ \\$$$$$$$\\       \\$$$$$$  |\\$$$$$$$ |$$ | $$ | $$ |\\$$$$$$$\\ \r\n" +
                         " \\______/ \\__|  \\__| \\_______|\\__|  \\__| \\_______|       \\______/  \\_______|\\__| \\__| \\__| \\_______|\r\n" +
                         "                                                                                                   \r\n" +
                         "                                                                                                  ";
            CenterElement(mainBanner);
            ResetForeGroundColor();
        }
        public static void RenderExitSpacebar()
        {
            SetForeGroundColor(ForeGroundColors.Magenta);
            string ExitSpaceBar = "╔═════════════════════════════════════════════════════════╗\r\n" +
                                  "║                  Press SPACEBAR to exit                 ║\r\n" +
                                  "╚═════════════════════════════════════════════════════════╝";
            CenterElement(ExitSpaceBar);
            ResetForeGroundColor();
        }
        public static void SetForeGroundColor (ForeGroundColors color)
        {
            switch (color)
            {
                case ForeGroundColors.Green:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case ForeGroundColors.Magenta:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case ForeGroundColors.Yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case ForeGroundColors.DarkCyan:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
            }    
        }
        public static void ResetForeGroundColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void CenterElement(string element)
        {
            int consoleWidth = Console.WindowWidth;
            string [] lines = element.Split(new[] { "\r\n" }, StringSplitOptions.None);
            foreach (var line in lines)
            {
                int padding = (consoleWidth - line.Length) / 2;
                Console.WriteLine(new string(' ', padding) + line);
            }
        }
        public static void CenterCreditElement(Dictionary<string, string> dictionary, int maxKeyLength, int maxValueLength)
        {
            int consoleWidth = Console.WindowWidth;

            foreach (KeyValuePair<string, string> kvp in dictionary)
            {
                int currentKeyLength = maxKeyLength - kvp.Key.Length;
                int currentValueLength = maxValueLength - kvp.Value.Length;
                string line = $"\x1b[96m{kvp.Key}\x1b[39m" + new string(' ', currentKeyLength) + " : " + kvp.Value + new string(' ', currentValueLength);
                // TO-DO: Fix the padding calculation. This is not OK for large screens
                int padding = (int)((consoleWidth - line.Length) / 1.8);
                Console.WriteLine(new string(' ', padding > 0 ? padding : 0) + line);
            }
        }


        // This works but we need to refactor it.
        // Not sure where I will use this.

        public static void RenderMap(Map map, Snake snake)
        {
            int mapHeight = map.GetHeight();
            int mapWidth = map.GetWidth();
            int[,] mapArray = map.GetMapArray();
            List<(int x, int y)> snakeBody = snake.GetSnakeBody();

            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {

                    if (mapArray[i, j] == 1)
                    {
                        if (i == 0 && j == 0)
                        {
                            Console.Write("╔");
                        }
                        else if (i == mapHeight - 1 && j == 0)
                        {
                            Console.Write("╚");
                        }
                        else if (j == mapWidth - 1 && i == 0)
                        {
                            Console.Write("╗");
                        }
                        else if (j == mapWidth - 1 && i == mapHeight - 1)
                        {
                            Console.Write("╝");
                        }
                        else if (i == 0 || i == mapHeight - 1)
                        {
                            Console.Write("═");
                        }
                        else if (j == 0 || j == mapWidth - 1)
                        {
                            Console.Write("║");
                        }
                    }
                    else if (snakeBody.Contains((i, j)))
                    {
                        if (snakeBody[0].Equals((i, j)))
                        {
                            Console.Write("o");
                        }
                        else
                        {
                            Console.Write("-");
                        }
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.ReadLine();

        }
    }
}
