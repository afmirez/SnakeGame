using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    internal interface ILevel
    {
        void StartLevel(GameContext context);
        void UpdateLevel(GameContext context);
        void EndLevel(GameContext context);
    }
}
