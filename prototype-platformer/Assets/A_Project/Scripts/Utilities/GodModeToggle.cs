using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PixelAdventure
{
    public class GodModeToggle : MonoBehaviour
    {
        Toggle tg;

        private void Awake()
        {
            tg = GetComponent<Toggle>();
        }

        public void Activate()
        {
            if (tg.isOn)
            {
                GameInfo.Instance.isInGodMod = true;
            }
            else
            {
                GameInfo.Instance.isInGodMod = false;
            }
        }
    }
}
