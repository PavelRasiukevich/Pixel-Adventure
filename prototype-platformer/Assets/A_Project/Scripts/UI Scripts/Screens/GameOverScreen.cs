using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class GameOverScreen : BaseScreen
    {
        public const string EXIT_TO_MAIN_MENU = "EXIT_TO_MAIN_MENU";

        public void OnContinuePressed()
        {
            Exit(EXIT_TO_MAIN_MENU);
        }

        public override void ShowScreen()
        {
            base.ShowScreen();
        }
    }
}
