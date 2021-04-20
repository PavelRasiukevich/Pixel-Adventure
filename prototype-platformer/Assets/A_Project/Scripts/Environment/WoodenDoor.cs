using PixelAdventure.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class WoodenDoor : BaseDoor
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            IControllable player = collision.GetComponentInParent<IControllable>();

            if (player != null)
            {
                OnDoorEntered.Invoke();
            }
        }
    }
}
