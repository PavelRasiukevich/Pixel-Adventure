using System;
using UnityEngine;

namespace PixelAdventure
{
    public class DungeonGameScreen : BaseScreen
    {
        public const string EXIT_TO_MENU = "EXIT_TO_MENU";
        public const string EXIT_TO_NEXT_LVL = "EXIT_TO_NEXT_LVL";

        [SerializeField] IronDoor door;

      
        private void OnEnable()
        {
            door.OnDoorEntered += OnDoorInteredHandler;
        }

        private void OnDisable()
        {
            door.OnDoorEntered -= OnDoorInteredHandler;
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
                Time.timeScale = 0;
                Exit(EXIT_TO_MENU);
            }
        }
    }
}
