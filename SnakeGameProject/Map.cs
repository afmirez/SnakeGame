using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    internal abstract class Map
    {
        protected int _width;
        protected int _height;
        protected int[,] map;

        public Map( int width, int height) {
            _height = height;
            _width = width;
            map = new int[_width, _height];
        }

        public abstract void CreateMap();

        //public virtual void CreateMap()
        //{

        //    for (int i = 0; i < _width; i++)
        //    {
        //        for (int j = 0; j < _height; j++)
        //        {
        //            if (i == 0 || i == _width - 1 || j == 0 || j == _height - 1)
        //            {
        //                map[i, j] = 1;
        //            }
        //            else
        //            {
        //                map[i, j] = 0;
        //            }
        //        }
        //    }
        //}
        //public void CreateBasicMap()
        //{
        //    for (int i = 0; i < _width; i++)
        //    {
        //        for (int j = 0; j < _height; j++)
        //        {
        //            if (i == 0 || i == _width - 1 || j == 0 || j == _height - 1)
        //            {
        //                map[i, j] = 1;
        //            }
        //            else
        //            {
        //                map[i, j] = 0;
        //            }
        //        }
        //    }
        //}

        // TO-DO : impe,emtar render visual class
        //public void PrintMap()
        //{
        //    for (int i = 0; i < _width; i++)
        //    {
        //        for (int j = 0; j < _height; j++)
        //        {
        //            if (map[i, j] == 1)
        //            {
        //                Console.Write("#");
        //            }
        //            else
        //            {
        //                Console.Write(" ");
        //            }
        //        }
        //        Console.WriteLine();
        //    }
        //}
    }
}
