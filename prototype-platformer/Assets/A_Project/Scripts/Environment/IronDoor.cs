using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelAdventure.Interfaces;
using TMPro;

namespace PixelAdventure
{
    public class IronDoor : BaseDoor
    {

        public readonly int DOOR_STATE = Animator.StringToHash("State");

        [SerializeField] Leveler leveler;

        private Animator doorAnim;

        private void Awake()
        {
            doorAnim = GetComponent<Animator>();
            leveler.OnLevelerActivated += OnEventHandler;
        }

        private void OnEventHandler()
        {
            doorAnim.SetInteger(DOOR_STATE, (int)DoorState.Open);
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
