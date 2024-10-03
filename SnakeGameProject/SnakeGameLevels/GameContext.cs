using SnakeGameProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    public class GameContext
    {
        private ILevel _currentLevel;
        private Player _player;
        public Snake _snake;
        private Food _food;
        private Map _map;
        public int currentScore = 0;
        public GameContext(Player player)
        {
            // Yo creo que hay muchos valores sueltos como la posicion de la comida y la serpiente, tamano del mapa.
            // Esto deberia cargarse desde un JSON, hacerlo al final para avanzar. 
            _player = player;
            _map = new Map(13,38);
            _snake = new Snake(7, 14);
            _food = new Food((5, 5));
            _currentLevel = new LevelOne();
            // Lo que sigue es trabajar en el nivel 1, que es el que se carga por defecto.
        }

        public void testInit ()
        {
            // La serpiente se mueve!!
            Console.WriteLine();
            SnakeGameVisualRenders.RenderMap(_map, _snake);
            Console.ReadLine();
            _snake.ExecuteMoveAction("up");
            SnakeGameVisualRenders.RenderMap(_map, _snake);
            Console.ReadLine();
            _snake.ExecuteMoveAction("up");
            SnakeGameVisualRenders.RenderMap(_map, _snake);
            Console.ReadLine();
            _snake.ExecuteMoveAction("up");
            SnakeGameVisualRenders.RenderMap(_map, _snake);
            Console.ReadLine();
            _snake.ExecuteMoveAction("up");
            SnakeGameVisualRenders.RenderMap(_map, _snake);
            Console.ReadLine();
            _snake.ExecuteMoveAction("right");
            SnakeGameVisualRenders.RenderMap(_map, _snake);
            Console.ReadLine();
            _snake.ExecuteMoveAction("right");
            SnakeGameVisualRenders.RenderMap(_map, _snake);
            Console.ReadLine();
            _snake.ExecuteMoveAction("right");
            SnakeGameVisualRenders.RenderMap(_map, _snake);
            Console.ReadLine();
            _snake.ExecuteMoveAction("down");
            SnakeGameVisualRenders.RenderMap(_map, _snake);
            Console.ReadLine();
            _snake.ExecuteMoveAction("down");
            SnakeGameVisualRenders.RenderMap(_map, _snake);
        }
    }
}