using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Linq;


namespace SnakeGameProject
{
    class GameLogic
    {
        // 1. Implementar change level para cambiar valor de propiedades
        private Snake _snake;
        private Map _map;
        private Action SnakeMovementHandler;
        private System.Timers.Timer? generateFoodTimer;
        private System.Timers.Timer? removeFoodTimer;
        private bool isSnakeMoving { get; set; }

        private bool isGameRunning;
        public GameLogic(Map map, Snake snake) {
            isGameRunning = true;
            _map = map;
            _snake = snake;
            SetTimers();
            SnakeMovementHandler += OnSnakeMoving;
        }

       public void OnSnakeMoving ()
       {
            if (isGameRunning)
            {
                IsThereCollision();
                CheckIfFoodEaten();
                if (_snake.isAlive)
                {
                    SnakeGameVisualRenders.UpdateSnake(_snake);
                }
        
            }
        }


        //public void RestartGame()
        //{
        //    isGameRunning = true;

        //}
        public void GameOver()
        {
            isGameRunning = false;
            generateFoodTimer?.Stop();
            generateFoodTimer?.Dispose();
            removeFoodTimer?.Stop();
            removeFoodTimer?.Dispose();
        }

        public void RestartGame()
        {
            
            isGameRunning = true;
            //_map.SetMap();
            SetTimers();
            generateFoodTimer?.Start();
            removeFoodTimer?.Start();
        }

        private void SetTimers()
        {
            generateFoodTimer = new System.Timers.Timer(10000);
            generateFoodTimer.Elapsed += OnGenerateFoodTimer;
            generateFoodTimer.AutoReset = true;
            generateFoodTimer.Enabled = true;

            removeFoodTimer = new System.Timers.Timer(5000);
            removeFoodTimer.Elapsed += OnRemoveFoodTimer;
            removeFoodTimer.AutoReset = true;
            removeFoodTimer.Enabled = true;
        }
        private void OnGenerateFoodTimer(Object source, ElapsedEventArgs e)
        {
            int mapHeight = _map.GetHeight();
            int mapWidth = _map.GetWidth();
            (int, int) foodPosition = (new Random().Next(1, mapHeight - 1), new Random().Next(1, mapWidth - 1));
            Food.SetFoodPosition(foodPosition);
            SnakeGameVisualRenders.UpdateFood(foodPosition);
        }
        private void OnRemoveFoodTimer(Object source, ElapsedEventArgs e)
        {
            (int x, int y)? lastFoodPosition = Food.GetFoodPosition();
            SnakeGameVisualRenders.RemoveFood(lastFoodPosition);
            Food.SetFoodPosition(null);
        }

        public void MoveSnake(Snake snake, SnakeMovement lastMovement, Map map)
        {
            
            SnakeGameVisualRenders.RenderMap(_map, _snake);
            
            isSnakeMoving = true;
            ConsoleKeyInfo key;
            SnakeMovement currentMovement = lastMovement;

            while (isGameRunning)
            {
                // Defines how fast the snake moves. This should be sent from the level.
                Thread.Sleep(70);
                // No se si hacerlo aca, o solamente suscribirme a cambios
                //SnakeGameVisualRenders.ShowStats();
                if (snake.isAlive)
                {
                    snake.ExecuteMoveAction(currentMovement);
                    SnakeMovementHandler?.Invoke();

                    if (Console.KeyAvailable)
                    {
                        key = Console.ReadKey(true);
                        switch (key.Key)
                        {
                            case ConsoleKey.UpArrow:
                                if (currentMovement != SnakeMovement.Down)
                                    currentMovement = SnakeMovement.Up;
                                break;
                            case ConsoleKey.DownArrow:
                                if (currentMovement != SnakeMovement.Up)
                                    currentMovement = SnakeMovement.Down;
                                break;
                            case ConsoleKey.LeftArrow:
                                if (currentMovement != SnakeMovement.Right)
                                    currentMovement = SnakeMovement.Left;
                                break;
                            case ConsoleKey.RightArrow:
                                if (currentMovement != SnakeMovement.Left)
                                    currentMovement = SnakeMovement.Right;
                                break;
                            case ConsoleKey.Escape:
                                isGameRunning = false;
                                return;
                        }
                    }
                }
            }
        }
        public void IsThereCollision()
        {
            int[,] arrayMap = _map.GetMap();
            (int x, int y) snakeHead = _snake.GetSnakeHead();
            List<(int, int)> snakeBody = _snake.GetSnakeBody();

            // Wall collision. 1 should be WALL
            if (arrayMap[snakeHead.x, snakeHead.y] == 1)
            {
                _snake.Die();

            }
            // Self collision
            for (int i = 1; i < snakeBody.Count; i++)
            {
                if (snakeBody[i] == snakeHead)
                {
                    _snake.Die();
                }
            }
        }
        public void CheckIfFoodEaten()
        {
            List<(int, int)> snakeBody = _snake.GetSnakeBody();
            (int x, int y) snakeHead = _snake.GetSnakeHead();
            (int, int)? foodPosition = Food.GetFoodPosition();
            if (foodPosition != null && snakeHead == foodPosition)
            {
                Food.SetFoodPosition(null);
                _snake.EatFood();
            }
        }
        public void CheckIfLevelCompleted(Snake snake)
        {
            throw new NotImplementedException();
        }

    }
}