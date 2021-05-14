using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelAdventure.Interfaces;
using TMPro;
using UnityEngine.Events;

namespace PixelAdventure
{
    public class IronDoor : BaseDoor
    {
        [SerializeField] UnityEvent unityEvent;

        public readonly int DOOR_STATE = Animator.StringToHash("State");

        [SerializeField] Leveler leveler;

        private Animator doorAnim;

        private void Awake()
        {
            doorAnim = GetComponent<Animator>();
        }

        public void OnEventHandler()
        {
            doorAnim.SetInteger(DOOR_STATE, (int)DoorState.Open);
            CanEnter = true;
            unityEvent.Invoke();
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
