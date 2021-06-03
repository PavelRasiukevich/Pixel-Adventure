using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelAdventure.Interfaces;
using System;
using TMPro;

namespace PixelAdventure
{
    public class Leveler : MonoBehaviour
    {
        private readonly int LEV_STATE = Animator.StringToHash("Leveler_State");

        private Animator levelerAnim;

        [SerializeField] Bridge bridge;
        [SerializeField] Canvas display;
        [SerializeField] TextMeshProUGUI text;

        bool On;
        int intValue;

        public bool IsRepaired { get; set; }
        public bool IsInteractable { get; set; } = true;

        private void Awake()
        {
            GetEnvironmentData();
            bridge.ActivateBridge(bridge.IsActive);
            levelerAnim = GetComponent<Animator>();
            levelerAnim.SetInteger(LEV_STATE, intValue);
        }

        private void GetEnvironmentData()
        {
            IsRepaired = GameInfo.Instance.EnvironmentData.IsLvlArmRepaired;
            bridge.IsActive = GameInfo.Instance.EnvironmentData.IsBridgeActivated;
            On = GameInfo.Instance.EnvironmentData.IsLvlArmOn;
            intValue = GameInfo.Instance.EnvironmentData.LvlArmAnimInteger;
        }

        private void SetEnvironmentData()
        {
            GameInfo.Instance.EnvironmentData.IsLvlArmRepaired = IsRepaired;
            GameInfo.Instance.EnvironmentData.IsBridgeActivated = bridge.IsActive;
            GameInfo.Instance.EnvironmentData.IsLvlArmOn = On;
            GameInfo.Instance.EnvironmentData.LvlArmAnimInteger = levelerAnim.GetInteger(LEV_STATE);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {

            IControllable player = collision.GetComponentInParent<IControllable>();

            if (player != null)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (IsRepaired == false)
                    {
                        if (GameInfo.Instance.CharData.HasGear)
                        {
                            Repaire(player);
                        }
                    }
                    else
                    {
                        UseLevelArm();
                    }
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IControllable player = collision.GetComponentInParent<IControllable>();

            if (player != null)
            {
                ShowDisplay();

                if (IsRepaired == false)
                {
                    if (GameInfo.Instance.CharData.HasGear)
                        text.text = "E to repaire";
                    else
                        text.text = "Broken";
                }
                else
                {
                    text.text = "E to use";
                }
            }
        }

        private void UseLevelArm()
        {
            bridge.ActivateBridge(!On);
            On = !On;

            if (On)
                levelerAnim.SetInteger(LEV_STATE, 1);
            else
                levelerAnim.SetInteger(LEV_STATE, 0);

            SetEnvironmentData();
        }

        private void Repaire(IControllable player)
        {
            On = true;
            IsRepaired = true;
            levelerAnim.SetInteger(LEV_STATE, 1);
            bridge.ActivateBridge(On);
            GameInfo.Instance.CharData.HasGear = false;

            player.Inventory.SlotGroup.FindItemByName(Values.GEAR);
            SetEnvironmentData();
        }

        private void ShowDisplay()
        {
            display.gameObject.SetActive(true);
        }

        private void HideDisplay()
        {
            display.gameObject.SetActive(false);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            HideDisplay();
        }
    }
}
