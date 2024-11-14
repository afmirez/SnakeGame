using SnakeGameProject.Core;
using SnakeGameProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject.VisualRenders
{
    class VisualUtils
    {
        private static GameContext _gameContext;

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

        private static int mapPadding = 0;
        private static int mapHeight = 0;

        public static void SuscribeToEvents()
        {
            _gameContext.currentScoreChangeHandler += UpdateStatsCurrentScore;
            _gameContext.playerMaxScoreUpdateHandler += UpdateStatsMaxScore;
            _gameContext.levelCompleteHandler += UpdateCurrentLevel;
        }
        public static void UnsuscribeToEvents()
        {
            _gameContext.currentScoreChangeHandler -= UpdateStatsCurrentScore;
            _gameContext.playerMaxScoreUpdateHandler -= UpdateStatsMaxScore;
            _gameContext.levelCompleteHandler -= UpdateCurrentLevel;
        }

        private static int scoresMaxLength = 0;
        public static void SetGameContext(GameContext gameContext)
        {
            _gameContext = gameContext;
        }

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

        public static int GetMapHeight()
        {
            return mapHeight;
        }

        public static int GetMapPadding()
        {
            return mapPadding;
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
        public static void SetForeGroundColor(ForeGroundColors color)
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
            string[] lines = element.Split(new[] { "\r\n" }, StringSplitOptions.None);
            foreach (var line in lines)
            {
                int padding = (consoleWidth - line.Length) / 2;
                Console.WriteLine(new string(' ', padding) + line);
            }
        }
        public static void CenterMap(string element)
        {
            int padding = 0;
            int consoleWidth = Console.WindowWidth;
            string[] lines = element.Split(new[] { "\r\n" }, StringSplitOptions.None);
            mapPadding = (consoleWidth - lines[0].Length) / 2;
            mapHeight = lines.Length;

            RenderAppBanner();
            foreach (var line in lines)
            {
                padding = (consoleWidth - line.Length) / 2;
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
            string mapString = "";


            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    if (mapArray[i, j] == 1) // Dibujar solo las paredes
                    {
                        if (i == 0 && j == 0) mapString = mapString + "╔";
                        else if (i == mapHeight - 1 && j == 0) mapString = mapString + "╚";
                        else if (j == mapWidth - 1 && i == 0) mapString = mapString + "╗";
                        else if (j == mapWidth - 1 && i == mapHeight - 1) mapString = mapString + "╝";
                        else if (i == 0 || i == mapHeight - 1) mapString = mapString + "═";
                        else if (j == 0 || j == mapWidth - 1) mapString = mapString + "║";
                    }
                    else
                    {
                        mapString = mapString + " ";
                    }
                }

                mapString = mapString + "\r\n";
            }
            CenterMap(mapString);
            ShowStats();
        }
        public static void UpdateSnake(Snake snake)
        {
            // The use of mapPadding is necessary to adjust the snake position to the centered map
            // Logic is 0 based, so we need to add the padding to the x position
            // This is just for visual render purposes. Logic is still 0 based

            int topSpaceMenu = GetMainBannerHeight();
            (int x, int y) oldTail = snake.GetSnakeBody().Last();
            var snakeBody = snake.GetSnakeBody();
            (int x, int y) newHead = snakeBody[0];
            Console.SetCursorPosition(newHead.y + mapPadding, newHead.x + topSpaceMenu);
            Console.Write("o");
            for (int i = 1; i < snakeBody.Count; i++)
            {
                (int x, int y) bodyPart = snakeBody[i];
                Console.SetCursorPosition(bodyPart.y + mapPadding, bodyPart.x + topSpaceMenu);
                Console.Write("x");
            }
            Console.SetCursorPosition(oldTail.y + mapPadding, oldTail.x + topSpaceMenu);
            Console.Write(" ");
        }
        public static void UpdateFood((int x, int y)? foodsPosition)
        {
            int topSpaceMenu = GetMainBannerHeight();
            (int x, int y)? foodPosition = foodsPosition;
            if (foodPosition != null)
            {
                int foodX = foodPosition.Value.x;
                int foodY = foodPosition.Value.y;

                Console.SetCursorPosition(foodY + mapPadding, foodX + topSpaceMenu);
                Console.Write("@");
            }
        }
        public static void RemoveFood((int x, int y)? lastFoodPosition)
        {
            int topSpaceMenu = GetMainBannerHeight();
            (int x, int y)? foodPosition = lastFoodPosition;
            if (foodPosition != null)
            {
                int foodX = foodPosition.Value.x;
                int foodY = foodPosition.Value.y;
                Console.SetCursorPosition(foodY + mapPadding, foodX + topSpaceMenu);
                Console.Write(" ");
            }
        }
        public static void ShowStats()
        {

            int maxKeyLength = 0;
            int maxValueLength = 0;

            Dictionary<string, int> gameStats = new Dictionary<string, int>
            {
                { "Current Score", _gameContext.currentScore },
                { "Max Score", _gameContext.maxScore }
            };


            foreach (KeyValuePair<string, int> kvp in gameStats)
            {
                int currentKeyLength = kvp.Key.Length;
                int currentValueLength = kvp.Value.ToString().Length;
                maxKeyLength = currentKeyLength > maxKeyLength ? currentKeyLength : maxKeyLength;
                maxValueLength = currentValueLength > maxValueLength ? currentValueLength : maxValueLength;
            }

            scoresMaxLength = maxKeyLength + maxValueLength + 2;

            int top = GetMainBannerHeight() + GetMapHeight();


            CenterElement($"\x1b[93m{_gameContext.currentLevelName}\x1b[39m");

            foreach (KeyValuePair<string, int> kvp in gameStats)
            {
                int currentKeyLength = maxKeyLength - kvp.Key.Length;
                string line = $"\x1b[96m{kvp.Key}\x1b[39m" + new string(' ', currentKeyLength) + " : " + kvp.Value;
                Console.WriteLine(new string(' ', mapPadding) + line);

            }
        }
        public static void UpdateCurrentLevel()
        {
            int top = GetMainBannerHeight() + GetMapHeight();
            int left = scoresMaxLength + mapPadding;
            int stringLength = _gameContext.currentLevelName.Length;
            Console.SetCursorPosition(left, top);
            Console.Write(new string(' ', stringLength));
            Console.SetCursorPosition(left, top);
            Console.Write(_gameContext.currentLevelName);
        }
        public static void UpdateStatsCurrentScore()
        {
            int top = GetMainBannerHeight() + GetMapHeight() + 1;
            int left = scoresMaxLength + mapPadding;
            Console.SetCursorPosition(left, top);
            Console.Write("   ");
            Console.SetCursorPosition(left, top);
            Console.Write(_gameContext.currentScore);
        }

        public static void UpdateStatsMaxScore()
        {
            int top = GetMainBannerHeight() + GetMapHeight() + 2;
            int left = scoresMaxLength + mapPadding;
            Console.SetCursorPosition(left, top);
            Console.Write("   ");
            Console.SetCursorPosition(left, top);
            Console.Write(_gameContext.maxScore);
        }
    }
}
