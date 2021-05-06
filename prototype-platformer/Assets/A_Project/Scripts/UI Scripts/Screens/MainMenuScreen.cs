using UnityEngine;

namespace PixelAdventure
{
    public class MainMenuScreen : BaseScreen
    {
        public const string EXIT_TO_OPTIONS = "EXIT_TO_OPTIONS";
        public const string EXIT_TO_GAME = "EXIT_TO_GAME";
        public const string EXIT_TO_CREDITS = "EXIT_TO_CREDITS";
        public const string EXIT_FROM_APP = "EXIT_FROM_APP";
        public const string LOAD_GAME = "LOAD_GAME";

        public override void ShowScreen()
        {
            base.ShowScreen();
            Time.timeScale = 1;

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

        public void OnExitPressed()
        {
            Exit(EXIT_FROM_APP);
        }

        public void OnLoadGamePressed()
        {
            Exit(LOAD_GAME);
        }

    }
}
