namespace SnakeGameProject.Entities
{
    static public class Food
    {
        static private (int x, int y)? _foodPosition { get; set; }

        public static (int x, int y)? GetFoodPosition()
        {
            return _foodPosition;
        }

        public static void SetFoodPosition((int x, int y)? position)
        {
            if (position != null)
            {
                _foodPosition = position;
            }
            else
            {
                _foodPosition = null;
            }
        }

    }
}