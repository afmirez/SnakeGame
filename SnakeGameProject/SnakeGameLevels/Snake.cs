using System.Security.Cryptography.X509Certificates;

namespace SnakeGameProject
{
    public class Snake
    {
        private List<(int x, int y)> _snakeBody = new List<(int x, int y)>();
        private Action MoveUp;
        private Action MoveDown;
        private Action MoveLeft;
        private Action MoveRight;

        public event Action SnakeDieHandler;
        public event Action SnakeEatHandler;

        public bool isAlive { get; private set; }

        private int initXPosition;
        private int initHeadPosition;

        public Snake(int xPosition, int head)
        {
            isAlive = true;
            initXPosition = xPosition;
            initHeadPosition = head;
            InitSnake(xPosition, head);
            InitMoveActions();
        }
        private void InitSnake(int x, int y) {
            for (int i = 1; i <= 7; i++) {
                _snakeBody.Add((x, y - i));
            }
        }
        private void InitMoveActions()
        {
            MoveUp = () => MoveSnake((-1,0));
            MoveDown = () => MoveSnake((1, 0));
            MoveLeft = () => MoveSnake((0, -1));
            MoveRight = () => MoveSnake((0, 1));
        }
        public List<(int x, int y)> GetSnakeBody()
        {
            return _snakeBody;
        }

        public (int x, int y) GetSnakeHead()
        {
            return _snakeBody[0];
        }
        public void MoveSnake((int x, int y) direction)
        {
            (int x, int y) newHead = (direction.x + _snakeBody[0].x, direction.y + _snakeBody[0].y);

            for (int i = _snakeBody.Count - 1; i > 0; i--)
            {
                _snakeBody[i] = _snakeBody[i - 1];
            }
            _snakeBody[0] = newHead;
        }
        public void ExecuteMoveAction(SnakeMovement move)
        {
            switch (move)
            {
                case SnakeMovement.Up:
                    MoveUp();
                    break;
                case SnakeMovement.Down:
                    MoveDown();
                    break;
                case SnakeMovement.Left:
                    MoveLeft();
                    break;
                case SnakeMovement.Right:
                    MoveRight();
                    break;
            }
        }
        public void EatFood()
        {
            (int x, int y) tail = _snakeBody.Last();
            (int x , int y ) newElement = (tail.x, tail.y - 1);
            _snakeBody.Add(newElement);
            SnakeEatHandler?.Invoke(); 
        }
        public void Die ()
        {
            isAlive = false;
            SnakeDieHandler?.Invoke();  
        }

        public void RegenerateSnake()
        {
            _snakeBody.Clear();
            InitSnake(initXPosition, initHeadPosition);
            isAlive = true;
        }

    }
}
