using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelAdventure
{
    public class GameScreen : BaseScreen
    {
        public const string EXIT_TO_MENU = "EXIT_TO_MENU";
        public const string EXIT_TO_NEXT_LVL = "EXIT_TO_NEXT_LVL";
        public const string EXIT_TO_GAMEOVER = "EXIT_TO_GAMEOVER";

        [SerializeField] BaseDoor door;
        [SerializeField] TextMeshProUGUI lifeAmountLabel;
        [SerializeField] BaseController character;

        public override void ShowScreen()
        {
            base.ShowScreen();

            foreach (var lvl in GameInfo.Instance.LevelConfig)
            {
                if (SceneManager.GetActiveScene().name.Equals(lvl.Name))
                    GameInfo.Instance.LevelName = lvl.Name;
            }

            GameInfo.Instance.IsGameOverScreenActive = false;
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

        private void LifeLostHandler()
        {
            GameInfo.Instance.LifeAmount--;
            lifeAmountLabel.text = GameInfo.Instance.LifeAmount.ToString();
        }

        private void OnDoorInteredHandler()
        {
            foreach (var lvl in GameInfo.Instance.LevelConfig)
            {
                if (SceneManager.GetActiveScene().name.Equals(lvl.Name))
                {
                    GameInfo.Instance.LevelComplited(lvl.Index);
                }
            }

            Exit(EXIT_TO_NEXT_LVL);
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                Exit(EXIT_TO_MENU);
            }

            if (GameInfo.Instance.LifeAmount == 0)
            {
                Time.timeScale = 0;
                Exit(EXIT_TO_GAMEOVER);
            }
        }
    }
}
