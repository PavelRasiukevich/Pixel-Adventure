using PixelAdventure.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class DetectionArea : MonoBehaviour
    {
        public Action<BaseController> TriggerInter { get; set; }
        public Action TriggerExit { get; set; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            BaseController player = collision.GetComponentInParent<BaseController>();

            if (player != null)
            {
                TriggerInter.Invoke(player);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            BaseController player = collision.GetComponentInParent<BaseController>();

            if (player != null)
            {
                TriggerExit.Invoke();
            }
        }
    }
}
