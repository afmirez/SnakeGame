using SnakeGameProject;

class Program
{
    public static void Main(string[] args)
    {
        RenderMenu();
    }

    public static void RenderMenu()
    {
        string[] mainMenuOptions = new string[] { "Start Game", "Scoreboard", "Exit" };
        IMenuStrategy menuStrategy = new IMainMenuStartegy();
        Menu menu = new Menu(mainMenuOptions, menuStrategy);
        menu.ShowMenu();
    }
}