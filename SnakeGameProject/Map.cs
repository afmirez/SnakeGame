using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    public class Map
    {
        private int _height;
        private int _width;
        private string[,] _map;
        private List<List<int>>? walls {  get; set; }

        public Map (int height, int width) {
            _height = height;
            _width = width;
            _map = new string[height, width];
        }

        public void BuildWalls()
        {
            // Vertical
            for (int i = 0; i < _width; i++)
            {
                _map[0, i] = "*";
                _map[_height - 1, i] = "*";
            }

            // Horizontal
            for (int j = 0; j < _height; j++) {
                _map[j, 0] = "*";
                _map[j, _width - 1] = "*";    
            }
        }
        
        public string[,] GetMap()
        {
            return _map;
        }
    }

    public class MapPrinter
    {
        public MapPrinter() { }
        public void PrintMap(Map map) {
            string[,] mapData = map.GetMap();
            for (int i = 0; i < mapData.GetLength(0); i++)
            {
                for (int j = 0; j < mapData.GetLength(1); j++) {
                    if (mapData[i,j] != null)
                    {
                        Console.Write(mapData[i, j] + "  ");
                    }
                    else
                    {
                        Console.Write(mapData[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }

    }
}
