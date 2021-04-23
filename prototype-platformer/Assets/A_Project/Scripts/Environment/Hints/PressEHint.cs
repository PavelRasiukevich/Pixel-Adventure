using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class PressEHint : MonoBehaviour
    {
        [SerializeField] Leveler leveler;

        private void Awake()
        {
            leveler.OnLevelerActivated += Handler;
        }

        private void Handler()
        {
            gameObject.SetActive(false);
        }
    }
}
