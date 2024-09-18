using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    internal class BasicMap : Map
    {
        public BasicMap(int width, int height) : base(width, height) { }

        public override void CreateMap()
        {
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    if (i == 0 || i == _width - 1 || j == 0 || j == _height - 1)
                    {
                        map[i, j] = 1;
                    }
                    else
                    {
                        map[i, j] = 0;
                    }
                }
                }
        }
    }
}
