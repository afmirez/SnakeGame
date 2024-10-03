namespace SnakeGameProject
{
    public class Food
    {
        private (int x, int y) _foodPosition { get; set; }

        public Food((int x, int y) initPosition)
        {
            _foodPosition = (initPosition);
        }
        public (int x, int y)? GetFoodPosition()
        {
            return _foodPosition;
        }

        public void SetFoodPosition((int x, int y) position)
        {
            _foodPosition = position;
        }

    }
}