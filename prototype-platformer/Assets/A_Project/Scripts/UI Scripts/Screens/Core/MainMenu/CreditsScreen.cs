using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class CreditsScreen : BaseScreen
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
