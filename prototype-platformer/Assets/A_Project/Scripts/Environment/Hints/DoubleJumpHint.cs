using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class DoubleJumpHint : MonoBehaviour
    {
        private void Awake()
        {

        }

        private void OnEnable()
        {
            gameObject.SetActive(true);
        }


        private void OnTriggerExit2D(Collider2D collision)
        {
            gameObject.SetActive(false);
        }
    }
}
