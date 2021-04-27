using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class GameOverScreen : BaseScreen
    {
        public const string EXIT_TO_MAIN_MENU = "EXIT_TO_MAIN_MENU";
        public const string RETRY = "RETRY";

        public void OnMainMenuPressed()
        {
            Exit(EXIT_TO_MAIN_MENU);
        }

        public void OnRetryPressed()
        {
            Exit(RETRY);
        }

        public override void ShowScreen()
        {
            base.ShowScreen();
            GameInfo.Instance.IsGameOverScreenActive = true;
        }
    }
}
