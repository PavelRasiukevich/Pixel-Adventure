namespace PixelAdventure
{
    public class MainMenuScreen : BaseScreen
    {
        public const string EXIT_TO_OPTIONS = "EXIT_TO_OPTIONS";
        public const string EXIT_TO_GAME = "EXIT_TO_GAME";
        public const string EXIT_TO_CREDITS = "EXIT_TO_CREDITS";

        public override void ShowScreen()
        {
            base.ShowScreen();
        }

        public void OnStartPressed()
        {
            Exit(EXIT_TO_GAME);
        }

        public void OnOptionsPressed()
        {
            Exit(EXIT_TO_OPTIONS);
        }

        public void OnCreditsPressed()
        {
            Exit(EXIT_TO_CREDITS);
        }

    }
}
