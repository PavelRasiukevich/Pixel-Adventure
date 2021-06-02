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

        public bool IsRepaired { get; set; }
        public bool IsInteractable { get; set; } = true;

        private void Awake()
        {
            levelerAnim = GetComponent<Animator>();
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
            bridge.gameObject.SetActive(!On);
            On = !On;

            if (On)
                levelerAnim.SetInteger(LEV_STATE, 1);
            else
                levelerAnim.SetInteger(LEV_STATE, 0);
        }

        private void Repaire(IControllable player)
        {
            On = true;
            IsRepaired = true;
            levelerAnim.SetInteger(LEV_STATE, 1);
            bridge.gameObject.SetActive(true);
            GameInfo.Instance.CharData.HasGear = false;

            player.Inventory.SlotGroup.FindItemByName(Values.GEAR);
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
