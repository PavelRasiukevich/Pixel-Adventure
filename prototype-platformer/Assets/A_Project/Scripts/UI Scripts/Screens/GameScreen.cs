using Cinemachine;
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

        [SerializeField] CinemachineConfiner confiner;
        [SerializeField] TextMeshProUGUI lifeAmountLabel;
        [SerializeField] TextMeshProUGUI scoreAmountLabel;
        [SerializeField] BaseController character;
        [SerializeField] Image dash;
        [SerializeField] Image doubleJump;
        [SerializeField] Image fastFall;

        [SerializeField] GameObject dashUIContainer;
        [SerializeField] GameObject fastFallUIContainer;
        [SerializeField] GameObject doubleJumpUIContainer;
        [SerializeField] GameObject itemsUIContainer;

        public override void ShowScreen()
        {
            base.ShowScreen();

            GameInfo.Instance.IsGameOverScreenActive = false;
            lifeAmountLabel.text = GameInfo.Instance.CharData.LiveAmount.ToString();
            scoreAmountLabel.text = $"Score: {GameInfo.Instance.GetScore()}";

            dashUIContainer.SetActive(GameInfo.Instance.AbilityUIData.IsDashIconVisible);
            fastFallUIContainer.SetActive(GameInfo.Instance.AbilityUIData.IsFastFallIconVisible);
            doubleJumpUIContainer.SetActive(GameInfo.Instance.AbilityUIData.IsDoubleJumpIconVisible);
        }

        private void OnEnable()
        {
            character.LifeLost += LifeLostHandler;
            character.GetRewardPoints = OnRewarded;
            character.DashHandled = OnDashReloadTimer;
            character.FastFallHandled = OnFastFallReloadTimer;
            character.DoubleJumpHandled = OnDoubleJumpReloadTimer;
            character.PowerUpConsumed = OnPowerUpConsumedHandler;
            character.ExiteFromBoundingShape = OnShapeBoundingExitHandler;
        }

        private void OnDisable()
        {
            character.LifeLost -= LifeLostHandler;
        }

        private void OnShapeBoundingExitHandler(PolygonCollider2D _polygonShape)
        {
            confiner.m_BoundingShape2D = _polygonShape;
        }

        private void OnPowerUpConsumedHandler(string _name)
        {
            switch (_name)
            {
                case Values.FAST_FALL:
                    fastFallUIContainer.SetActive(true);
                    GameInfo.Instance.AbilityUIData.IsFastFallIconVisible = true;
                    break;
                case Values.DOUBLE_JUMP:
                    doubleJumpUIContainer.SetActive(true);
                    GameInfo.Instance.AbilityUIData.IsDoubleJumpIconVisible = true;
                    break;
                case Values.DASH:
                    dashUIContainer.SetActive(true);
                    GameInfo.Instance.AbilityUIData.IsDashIconVisible = true;
                    break;
                case Values.GEAR_ITEM:
                    itemsUIContainer.SetActive(true);
                    break;
            }
        }

        private void OnFastFallReloadTimer()
        {
            fastFall.fillAmount = 0;
        }

        private void OnDashReloadTimer()
        {
            dash.fillAmount = 0;
        }

        private void OnDoubleJumpReloadTimer()
        {
            doubleJump.fillAmount = 0;
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

            if (dash.fillAmount < 1)
                dash.fillAmount += Time.deltaTime / GameInfo.Instance.CharData.DashReloadTime;

            if (fastFall.fillAmount < 1)
                fastFall.fillAmount += Time.deltaTime / GameInfo.Instance.CharData.FastFallReloadTime;

            if (doubleJump.fillAmount < 1)
                doubleJump.fillAmount += Time.deltaTime / GameInfo.Instance.CharData.DoubleJumpReloadTime;

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
