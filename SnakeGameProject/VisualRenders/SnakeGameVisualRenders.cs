using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    public enum ForeGroundColors
    {
        Green,
        Magenta,
    }
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


        // Private methods to help render the visual elements
        private static void SetForeGroundColor (ForeGroundColors color)
        {
            switch (color)
            {
                case ForeGroundColors.Green:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case ForeGroundColors.Magenta:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
            }    
        }

        private static void ResetForeGroundColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void CenterElement(string element)
        {
            int consoleWidth = Console.WindowWidth;
            string [] lines = element.Split(new[] { "\r\n" }, StringSplitOptions.None);
            foreach (var line in lines)
            {
                int padding = (consoleWidth - line.Length) / 2;
                Console.WriteLine(new string(' ', padding) + line);
            }
        }
    }
}
