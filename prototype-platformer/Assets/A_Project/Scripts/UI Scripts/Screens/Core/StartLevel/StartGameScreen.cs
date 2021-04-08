using System;
using UnityEngine;

namespace PixelAdventure
{
    public class StartGameScreen : BaseScreen
    {
        public const string EXIT_TO_MENU = "EXIT_TO_MENU";
        public const string EXIT_TO_NEXT_LVL = "EXIT_TO_NEXT_LVL";

        [SerializeField] IronDoor door;

      
        private void OnEnable()
        {
            door.OnDoorEntered += OnDoorInteredHandler;
        }

        private void OnDoorInteredHandler()
        {
            Exit(EXIT_TO_NEXT_LVL);
        }

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
