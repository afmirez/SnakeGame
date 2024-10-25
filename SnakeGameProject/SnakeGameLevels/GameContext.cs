using SnakeGameProject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    public class GameContext
    {
        private ILevel _currentLevel;
        private Player _player;
        public Snake _snake;
        private Map _map;
        public int currentScore = 0;
        public int maxScore;
        GameLogic gameLogic;

        public event Action currentScoreChangeHandler;
        public event Action playerMaxScoreUpdateHandler;

        public GameContext(Player player)
        {
            // Yo creo que hay muchos valores sueltos como la posicion de la comida y la serpiente, tamano del mapa.
            // Esto deberia cargarse desde un JSON, hacerlo al final para avanzar. 
            _player = player;
            _map = new Map(13,38);
            _snake = new Snake(7, 14);
            //currentScore = _player.MaxScore;
            maxScore = _player.MaxScore;
            _currentLevel = new LevelOne();
            // Lo que sigue es trabajar en el nivel 1, que es el que se carga por defecto.
            _snake.SnakeDieHandler += OnSnakeDie;
            _snake.SnakeEatHandler += onSnakeEat;
            gameLogic = new GameLogic(_map, _snake);

        }
        
        public void OnSnakeDie()
        {
            int top = SnakeGameVisualRenders.GetMainBannerHeight() + SnakeGameVisualRenders.GetMapHeight() + 2;
            int padding = SnakeGameVisualRenders.GetMapPadding();
            
            Console.SetCursorPosition(padding, top + 1);
            Console.WriteLine($"\x1b[91mTHE SNAKE HAS DIED\x1b[39m");
            gameLogic.GameOver();
            Console.SetCursorPosition(padding, top + 2);
            Console.WriteLine($"\x1b[95mPress SPACE to go back or ENTER to restart\x1b[39m");
            SnakeGameOptions();
            //Console.ReadLine();
        }

        public void SnakeGameOptions()
        {
            ConsoleKeyInfo selectedKey;
            do
            {
                selectedKey = Console.ReadKey(true);
            }
            while (selectedKey.Key != ConsoleKey.Spacebar &&
                   selectedKey.Key != ConsoleKey.Enter);

            if (selectedKey.Key == ConsoleKey.Spacebar)
            {
                Console.Clear();
                SnakeGameVisualRenders.RenderAppBanner();
            }
            else if (selectedKey.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                RestartGame();
                //gameLogic.GameOver();
                //gameLogic = new GameLogic(_map, _snake);
                //gameLogic.OnSnakeMoving();
            }
        }
        public void testInit ()
        {
            Console.Clear();
            
            gameLogic.MoveSnake(_snake, SnakeMovement.Right, _map);
        }

        public void RestartGame()
        {
            currentScore = 0;
            
            _snake.RegenerateSnake();
            gameLogic.RestartGame();
            maxScore = _player.MaxScore;
            gameLogic.MoveSnake(_snake, SnakeMovement.Right, _map);

        }

        public void onSnakeEat()
        {
            currentScore = currentScore + 1;
            currentScoreChangeHandler?.Invoke();
            //if (currentScore >  _player.MaxScore)
            //{
            //    _player.UpdateMaxScore(currentScore);
            //    maxScore = currentScore;
            //    playerMaxScoreUpdateHandler?.Invoke();
            //}

            // This will generate the update in the player update, the internal update of the maxScore, and the visual render
            if (currentScore > maxScore)
            {
                _player.UpdateMaxScore(currentScore);
                maxScore = currentScore;
                playerMaxScoreUpdateHandler?.Invoke();
            }

        }


        // Incluir logica del nivel -- Incluir metodo para cargar el siguiente nivel o set level

        // Incluir nuevo menu para regresar al inicio o continuar el nivel
        // Pensar en renders de final de juego        // Limpiar el codigo -- Ver si se puede mejorar los visual renders
        // Incluir logica del nivel -- Incluir metodo para cargar el siguiente nivel o set level
        // Incluir nuevo menu para regresar al inicio o continuar el nivel
        // Pensar en renders de final de juego


    }
}