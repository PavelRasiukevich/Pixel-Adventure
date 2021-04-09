using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace PixelAdventure
{
    public class Level_1_GameScreen : BaseScreen
    {
        public const string EXIT_TO_MENU = "EXIT_TO_MENU";
        public const string EXIT_TO_NEXT_LVL = "EXIT_TO_NEXT_LVL";

        [SerializeField] IronDoor door;

        private void OnEnable()
        {
            door.OnDoorEntered += OnDoorEnteredHandler;
        }

        private void OnDisable()
        {
            door.OnDoorEntered -= OnDoorEnteredHandler;
        }

        private void OnDoorEnteredHandler()
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
