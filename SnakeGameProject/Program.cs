using SnakeGameProject;

class Program
{
    public static void Main(string[] args)
    {
        RenderMenu();
    }

    public static void RenderMenu()
    {
        string[] mainMenuOptions = { "Start Game", "Credits", "Exit" };
        IMenuStrategy menuStrategy = new IMainMenuStrategy();
        int topSpaceMenu = SnakeGameVisualRenders.GetMainBannerHeight();
        Menu menu = new Menu(mainMenuOptions, menuStrategy, topSpaceMenu);
        SnakeGameVisualRenders.RenderAppBanner();
        menu.ShowMenu();
    }
}