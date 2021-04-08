using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelAdventure.Interfaces;

namespace PixelAdventure
{
    public class IronDoor : MonoBehaviour
    {
        public Action OnDoorEntered { get; set; }

        public readonly int DOOR_STATE = Animator.StringToHash("State");

        [SerializeField] Leveler leveler;

        private Animator doorAnim;
        private bool CanEnter { get; set; }

        private void Awake()
        {
            doorAnim = GetComponent<Animator>();
            leveler.OnLevelerActivated += OnEventHandler;
        }

        private void OnEventHandler()
        {
            doorAnim.SetInteger(DOOR_STATE, 1);
            CanEnter = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IControllable player = collision.GetComponentInParent<IControllable>();

            if (player != null)
            {
                if (CanEnter)
                    OnDoorEntered.Invoke();
            }
        }
    }
}
