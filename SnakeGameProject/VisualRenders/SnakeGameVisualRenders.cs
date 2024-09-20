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
            const string mainBanner = " $$$$$$\\                      $$\\                        $$$$$$\\                                    \r\n$$  __$$\\                     $$ |                      $$  __$$\\                                   \r\n$$ /  \\__|$$$$$$$\\   $$$$$$\\  $$ |  $$\\  $$$$$$\\        $$ /  \\__| $$$$$$\\  $$$$$$\\$$$$\\   $$$$$$\\  \r\n\\$$$$$$\\  $$  __$$\\  \\____$$\\ $$ | $$  |$$  __$$\\       $$ |$$$$\\  \\____$$\\ $$  _$$  _$$\\ $$  __$$\\ \r\n \\____$$\\ $$ |  $$ | $$$$$$$ |$$$$$$  / $$$$$$$$ |      $$ |\\_$$ | $$$$$$$ |$$ / $$ / $$ |$$$$$$$$ |\r\n$$\\   $$ |$$ |  $$ |$$  __$$ |$$  _$$<  $$   ____|      $$ |  $$ |$$  __$$ |$$ | $$ | $$ |$$   ____|\r\n\\$$$$$$  |$$ |  $$ |\\$$$$$$$ |$$ | \\$$\\ \\$$$$$$$\\       \\$$$$$$  |\\$$$$$$$ |$$ | $$ | $$ |\\$$$$$$$\\ \r\n \\______/ \\__|  \\__| \\_______|\\__|  \\__| \\_______|       \\______/  \\_______|\\__| \\__| \\__| \\_______|\r\n                                                                                                    \r\n                                                                                                  ";
            Console.WriteLine(mainBanner);

        }
    }
}
