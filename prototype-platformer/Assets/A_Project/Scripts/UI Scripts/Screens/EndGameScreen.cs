using UnityEngine;

namespace PixelAdventure
{
    public class EndGameScreen : BaseScreen
    {
        public const string EXIT_TO_MAIN_MENU = "EXIT_TO_MAIN_MENU";
        public const string EXIT_TO_DESKTOP = "EXIT_TO_DESKTOP";

        public override void ShowScreen()
        {
            base.ShowScreen();
            Debug.Log("EndGameScreen");
        }

        public void OnExitToMainMenuPressed()
        {
            Exit(EXIT_TO_MAIN_MENU);
        }

        public void OnExitToDesktopPressed()
        {
            Exit(EXIT_TO_DESKTOP);
        }
    }
}
