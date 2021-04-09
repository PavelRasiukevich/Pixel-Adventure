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

        public Action OnLevelerActivated { get; set; }

        private Animator levelerAnim;

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
                    levelerAnim.SetInteger(LEV_STATE, 1);
                    OnLevelerActivated.Invoke();
                }
            }
        }
    }
}
