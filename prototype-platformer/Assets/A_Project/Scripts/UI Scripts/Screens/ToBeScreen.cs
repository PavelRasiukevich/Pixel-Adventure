using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class ToBeScreen : BaseScreen
    {
        public const string EXIT_TO_MENU = "EXIT_TO_MENU";

        public override void ShowScreen()
        {
            base.ShowScreen();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Exit(EXIT_TO_MENU);
            }
        }
    }
}
