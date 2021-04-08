namespace PixelAdventure
{
    public class OptionsScreen : BaseScreen
    {
        public const string EXIT_TO_BACK_SCREEN = "EXIT_TO_BACK_SCREEN";

        public override void ShowScreen()
        {
            base.ShowScreen();
        }

        public void OnBackPressed()
        {
            Exit(EXIT_TO_BACK_SCREEN);
        }
    }
}
