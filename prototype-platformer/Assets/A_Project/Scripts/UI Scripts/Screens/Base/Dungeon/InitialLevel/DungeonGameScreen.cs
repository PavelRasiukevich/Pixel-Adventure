using System;
using TMPro;
using UnityEngine;

namespace PixelAdventure
{
    public class DungeonGameScreen : BaseScreen
    {
        public const string EXIT_TO_MENU = "EXIT_TO_MENU";
        public const string EXIT_TO_NEXT_LVL = "EXIT_TO_NEXT_LVL";
        public const string EXIT_TO_GAMEOVER = "EXIT_TO_GAMEOVER";

        [SerializeField] BaseDoor door;
        [SerializeField] TextMeshProUGUI lifeAmountLabel;
        [SerializeField] BaseController character;

        private void Awake()
        {
            lifeAmountLabel.text = GameInfo.Instance.LifeAmount.ToString();
        }

        private void OnEnable()
        {
            door.OnDoorEntered += OnDoorInteredHandler;
            character.LifeLost += LifeLostHandler;
        }

        private void OnDisable()
        {
            door.OnDoorEntered -= OnDoorInteredHandler;
            character.LifeLost -= LifeLostHandler;
        }

        private void  LifeLostHandler()
        {
            GameInfo.Instance.LifeAmount--;
            lifeAmountLabel.text = GameInfo.Instance.LifeAmount.ToString();
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

            if (GameInfo.Instance.LifeAmount == 0)
                Exit(EXIT_TO_GAMEOVER);
        }
    }
}
