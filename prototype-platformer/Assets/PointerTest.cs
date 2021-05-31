using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PixelAdventure
{
    public class PointerTest : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("DOWN");
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Debug.Log("UP");
        }
    }
}
