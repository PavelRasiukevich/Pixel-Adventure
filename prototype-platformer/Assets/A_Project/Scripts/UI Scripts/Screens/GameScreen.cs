
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PixelAdventure
{
    public class GameScreen : BaseScreen
    {
        public const string EXIT_TO_MENU = "EXIT_TO_MENU";
        public const string EXIT_TO_NEXT_LVL = "EXIT_TO_NEXT_LVL";
        public const string EXIT_TO_GAMEOVER = "EXIT_TO_GAMEOVER";

        [SerializeField] TextMeshProUGUI lifeAmountLabel;
        [SerializeField] TextMeshProUGUI scoreAmountLabel;
        [SerializeField] BaseController character;

        [SerializeField] AbilityGroup abilityGroup;

        AbilitySlot doubleJump;
        AbilitySlot fastFall;
        AbilitySlot dash;

        public override void ShowScreen()
        {
            base.ShowScreen();

            GameInfo.Instance.IsGameOverScreenActive = false;
            lifeAmountLabel.text = GameInfo.Instance.CharData.LiveAmount.ToString();
            scoreAmountLabel.text = $"Score: {GameInfo.Instance.GetScore()}";

        }

        private void OnEnable()
        {
            character.LifeLost += LifeLostHandler;
            character.GetRewardPoints = OnRewarded;
            character.DashHandled = OnDashReloadTimer;
            character.FastFallHandled = OnFastFallReloadTimer;
            character.DoubleJumpHandled = OnDoubleJumpReloadTimer;
            character.PowerUpConsumed = OnPowerUpConsumedHandler;
            character.ItemEquiped = OnItemEquipedHandler;
        }

        private void OnItemEquipedHandler(Item _item)
        {
            var _abiltySlot = abilityGroup.FindEmptyAbilitySlot();

            if (_abiltySlot)
            {
                _item.ApplyAbility();
                _abiltySlot.SetupAbilitySlot(_item.ItemAbilitySprite, _item.ItemAbilityName);
                _abiltySlot.SetPropsToDataManager();
            }
        }

        private void OnDisable()
        {
            character.LifeLost -= LifeLostHandler;
        }

        private void OnPowerUpConsumedHandler(string _name)
        {
            switch (_name)
            {
                case Values.PEARL:
                    lifeAmountLabel.text = GameInfo.Instance.CharData.LiveAmount.ToString();
                    break;
            }
        }

        private void OnFastFallReloadTimer()
        {
            fastFall = abilityGroup.GetAbilitySlotByName(Values.FASTFALL);
            fastFall.FillImg.fillAmount = 0;
        }

        private void OnDashReloadTimer()
        {
            dash = abilityGroup.GetAbilitySlotByName(Values.DASH);
            dash.FillImg.fillAmount = 0;
        }

        private void OnDoubleJumpReloadTimer()
        {
            doubleJump = abilityGroup.GetAbilitySlotByName(Values.DOUBLEJUMP);
            doubleJump.FillImg.fillAmount = 0;
        }

        private void OnRewarded()
        {
            scoreAmountLabel.text = $"Score: {GameInfo.Instance.GetScore()}";
        }

        private void LifeLostHandler()
        {
            GameInfo.Instance.CharData.LiveAmount--;
            lifeAmountLabel.text = GameInfo.Instance.CharData.LiveAmount.ToString();
        }

        private void Update()
        {
            if (doubleJump)
                if (doubleJump.FillImg.fillAmount < 1)
                    doubleJump.FillImg.fillAmount += Time.deltaTime / GameInfo.Instance.CharData.DoubleJumpReloadTime;

            if (fastFall)
                if (fastFall.FillImg.fillAmount < 1)
                    fastFall.FillImg.fillAmount += Time.deltaTime / GameInfo.Instance.CharData.FastFallReloadTime;

            if (dash)
                if (dash.FillImg.fillAmount < 1)
                    dash.FillImg.fillAmount += Time.deltaTime / GameInfo.Instance.CharData.DashReloadTime;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                Exit(EXIT_TO_MENU);
            }

            if (GameInfo.Instance.CharData.LiveAmount == 0)
            {
                Time.timeScale = 0;
                Exit(EXIT_TO_GAMEOVER);
            }
        }
    }
}
