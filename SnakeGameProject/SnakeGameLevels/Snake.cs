using System.Security.Cryptography.X509Certificates;

namespace SnakeGameProject
{
    public class Snake
    {
        private List<(int x, int y)> _snakeBody = new List<(int x, int y)>();

        public Action MoveUp;
        public Action MoveDown;
        public Action MoveLeft;
        public Action MoveRight;
        public Snake(int xPosition, int head)
        {
            InitSnake(xPosition, head);
            InitMoveActions();
        }
        private void InitSnake(int x, int y) {
            for (int i = 1; i <= 4; i++) {
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

        public void ExecuteMoveAction (string action)
        {
            switch (action)
            {
                case "up":
                    MoveUp();
                    break;
                case "down":
                    MoveDown();
                    break;
                case "left":
                    MoveLeft();
                    break;
                case "right":
                    MoveRight();
                    break;
            }

        }

        public List<(int x, int y)> GetSnakeBody()
        {
            return _snakeBody;
        }
        public (int,int) GetSnakeHead()
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

        public void EatFood()
        {
            //_snakeBody.Add()
        }

        public void Die ()
        {
            // Die
        }
    }
}
