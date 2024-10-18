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
        //private Food _food;
        private Map _map;
        public int currentScore = 0;
        GameLogic gameLogic;


        //Snake.SnakeDieHandler += OnSnakeDie;
        public GameContext(Player player)
        {
            // Yo creo que hay muchos valores sueltos como la posicion de la comida y la serpiente, tamano del mapa.
            // Esto deberia cargarse desde un JSON, hacerlo al final para avanzar. 
            _player = player;
            _map = new Map(13,38);
            _snake = new Snake(7, 14);
            //_food = new Food((5, 5));
            _currentLevel = new LevelOne();
            // Lo que sigue es trabajar en el nivel 1, que es el que se carga por defecto.
            _snake.SnakeDieHandler += OnSnakeDie;
            gameLogic = new GameLogic(_map, _snake);

        }
        
        public void OnSnakeDie()
        {
            Console.WriteLine("La serpiente ha muerto. Mostrar Game Over.");
            gameLogic.GameOver();
            Console.WriteLine("Puntaje: " + currentScore);
            Console.ReadLine();
        }

        public void testInit ()
        {
            Console.Clear();
            //SnakeGameVisualRenders.RenderMap(_map, _snake);
            gameLogic.MoveSnake(_snake, SnakeMovement.Right, _map);
        }


        // Limpiar el codigo -- Ver si se puede mejorar los visual renders

        // Incluir logica del nivel -- Incluir metodo para cargar el siguiente nivel o set level

        // Incluir nuevo menu para regresar al inicio o continuar el nivel
        // Pensar en renders de final de juego        // Limpiar el codigo -- Ver si se puede mejorar los visual renders
        // Incluir logica del nivel -- Incluir metodo para cargar el siguiente nivel o set level
        // Incluir nuevo menu para regresar al inicio o continuar el nivel
        // Pensar en renders de final de juego
    }
}