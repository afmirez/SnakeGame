using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    public class Map
    {
        private int _width { get;}
        private int _height { get; }
        private int[,] _map { get; }
        private const int WALL = 1;
        public Map(int height, int width)
        {
            _height = height;
            _width = width;
            _map = new int[_height, _width];
            SetMap();
        }
        public int GetWidth()
        {
            return _width;
        }
        public int GetHeight()
        {
            return _height;
        }
        public int[,] GetMapArray()
        {
            return _map;
        }
        public void SetMap()
        {
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    if (i == 0 || i == _height - 1 || j == 0 || j == _width - 1)
                    {
                        _map[i, j] = WALL;
                    }
                }
            }
        }
    }
}