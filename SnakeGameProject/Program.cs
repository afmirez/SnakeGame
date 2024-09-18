using SnakeGameProject;

class Program
{
    public static void Main(string[] args)
    {
        // Obj that handles the game menu, that is, it redirects the user to the action.
        // We avoid starting the game directly in the Main method beacuse there is a menu that the user can interact with.
        Menu menu = new Menu();
        menu.ShowMenu();

    }
}