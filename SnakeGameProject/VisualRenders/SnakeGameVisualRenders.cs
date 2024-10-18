using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SnakeGameProject
{

    public static class SnakeGameVisualRenders
    {
        private const string mainBanner = " $$$$$$\\                      $$\\                        $$$$$$\\                                    \r\n" +
             "$$  __$$\\                     $$ |                      $$  __$$\\                                   \r\n" +
             "$$ /  \\__|$$$$$$$\\   $$$$$$\\  $$ |  $$\\  $$$$$$\\        $$ /  \\__| $$$$$$\\  $$$$$$\\$$$$\\   $$$$$$\\  \r\n" +
             "\\$$$$$$\\  $$  __$$\\  \\____$$\\ $$ | $$  |$$  __$$\\       $$ |$$$$\\  \\____$$\\ $$  _$$  _$$\\ $$  __$$\\ \r\n" +
             " \\____$$\\ $$ |  $$ | $$$$$$$ |$$$$$$  / $$$$$$$$ |      $$ |\\_$$ | $$$$$$$ |$$ / $$ / $$ |$$$$$$$$ |\r\n" +
             "$$\\   $$ |$$ |  $$ |$$  __$$ |$$  _$$<  $$   ____|      $$ |  $$ |$$  __$$ |$$ | $$ | $$ |$$   ____|\r\n" +
             "\\$$$$$$  |$$ |  $$ |\\$$$$$$$ |$$ | \\$$\\ \\$$$$$$$\\       \\$$$$$$  |\\$$$$$$$ |$$ | $$ | $$ |\\$$$$$$$\\ \r\n" +
             " \\______/ \\__|  \\__| \\_______|\\__|  \\__| \\_______|       \\______/  \\_______|\\__| \\__| \\__| \\_______|\r\n" +
             "                                                                                                   \r\n" +
             "                                                                                                  ";
        public static void RenderAppBanner()
        {
            SetForeGroundColor(ForeGroundColors.Green);
            CenterElement(mainBanner);
            ResetForeGroundColor();
        }
        public static int GetMainBannerHeight()
        {
            return mainBanner.Split(new[] { "\r\n" }, StringSplitOptions.None).Length;
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
        public static void RenderMap(Map map, Snake snake)
        {
            Console.CursorVisible = false;

            int mapHeight = map.GetHeight();
            int mapWidth = map.GetWidth();
            int[,] mapArray = map.GetMapArray();

            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    if (mapArray[i, j] == 1) // Dibujar solo las paredes
                    {
                        if (i == 0 && j == 0) Console.Write("╔");
                        else if (i == mapHeight - 1 && j == 0) Console.Write("╚");
                        else if (j == mapWidth - 1 && i == 0) Console.Write("╗");
                        else if (j == mapWidth - 1 && i == mapHeight - 1) Console.Write("╝");
                        else if (i == 0 || i == mapHeight - 1) Console.Write("═");
                        else if (j == 0 || j == mapWidth - 1) Console.Write("║");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        public static void UpdateSnake(Snake snake)
        {
            (int x, int y) oldTail = snake.GetSnakeBody().Last();
            var snakeBody = snake.GetSnakeBody();

            (int x, int y) newHead = snakeBody[0];

            Console.SetCursorPosition(newHead.y, newHead.x);

            Console.Write("o"); 

            // Dibujar el resto del cuerpo
            for (int i = 1; i < snakeBody.Count; i++)
            {
                (int x, int y) bodyPart = snakeBody[i];
                Console.SetCursorPosition(bodyPart.y, bodyPart.x);
                Console.Write("x"); // Representa el cuerpo con "x"
            }

            Console.SetCursorPosition(oldTail.y, oldTail.x);

            Console.Write(" "); // Reemplaza la cola antigua con un espacio vacío
        }


        public static void UpdateFood((int x, int y)? foodsPosition)
        {
            // Dibujar la comida
            (int x, int y)? foodPosition = foodsPosition;
            if (foodPosition != null)
            {
                int foodX = foodPosition.Value.x;
                int foodY = foodPosition.Value.y;

                Console.SetCursorPosition(foodY, foodX);
                //Console.SetCursorPosition(foodPosition.y, foodPosition.x);
                Console.Write("F");
            }
        }

        public static void RemoveFood((int x, int y)? lastFoodPosition)
        {
            (int x, int y)? foodPosition = lastFoodPosition;
            if (foodPosition != null)
            {
                int foodX = foodPosition.Value.x;
                int foodY = foodPosition.Value.y;

                Console.SetCursorPosition(foodY, foodX);
                //Console.SetCursorPosition(foodPosition.y, foodPosition.x);
                Console.Write(" ");
            }
        }

    }
}
