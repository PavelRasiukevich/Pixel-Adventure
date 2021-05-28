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

        [SerializeField] TextMeshProUGUI hint;
        [SerializeField] Bridge bridge;
        [SerializeField] string msg_1;
        [SerializeField] string msg_2;

        public bool IsRepaired { get; set; }
        public bool IsInteractable { get; set; } = true;

        private void Awake()
        {
            levelerAnim = GetComponent<Animator>();
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (IsInteractable)
            {
                IControllable player = collision.GetComponentInParent<IControllable>();

                if (player != null)
                {
                    if (Input.GetAxis("Use") > 0)
                        if (IsRepaired)
                        {
                            levelerAnim.SetInteger(LEV_STATE, 1);
                            bridge.gameObject.SetActive(true);
                            hint.gameObject.SetActive(false);
                            IsInteractable = false;
                        }
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (IsInteractable)
            {
                IControllable player = collision.GetComponentInParent<IControllable>();

                if (player != null)
                {
                    hint.gameObject.SetActive(true);

                    if (GameInfo.Instance.CharData.HasGear)
                        IsRepaired = true;

                    if (IsRepaired == false)
                        hint.text = msg_1;
                    else
                        hint.text = msg_2;
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (IsInteractable)
            {
                IControllable player = collision.GetComponentInParent<IControllable>();

                if (player != null)
                {
                    hint.gameObject.SetActive(false);
                }
            }
        }
    }
}
