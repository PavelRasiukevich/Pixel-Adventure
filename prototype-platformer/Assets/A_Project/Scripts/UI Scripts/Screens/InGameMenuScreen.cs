using UnityEngine;

namespace PixelAdventure
{
    public class InGameMenuScreen : BaseScreen
    {
        public const string EXIT_TO_MAIN_MENU = "EXIT_TO_MAIN_MENU";
        public const string EXIT_TO_OPTIONS = "EXIT_TO_OPTIONS";
        public const string EXIT_TO_BACK_SCREEN = "EXIT_TO_BACK_SCREEN";
        public const string EXIT_FROM_APP = "EXIT_FROM_APP";

        public override void ShowScreen()
        {
            base.ShowScreen();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1;
                Exit(EXIT_TO_BACK_SCREEN);
            }
        }

        public void OnMainMenuPressed()
        {
            AppPrefs.DeleteObject(PrefsKeys.CHARACTER_DATA);
            GameInfo.Instance.Setup();
            Exit(EXIT_TO_MAIN_MENU);
        }

        public void OnOptionsPressed()
        {
            Exit(EXIT_TO_OPTIONS);
        }

        public void OnBackPressed()
        {
            Time.timeScale = 1;
            Exit(EXIT_TO_BACK_SCREEN);
        }

        public void OnExitPressed()
        {
            Exit(EXIT_FROM_APP);
        }
    }
}
