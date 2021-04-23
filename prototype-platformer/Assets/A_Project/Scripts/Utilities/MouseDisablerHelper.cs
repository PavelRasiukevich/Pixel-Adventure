using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PixelAdventure
{
    public class MouseDisablerHelper : MonoBehaviour
    {
        GameObject lastselect;

        void Awake()
        {
            lastselect = new GameObject();
        }

        void Update()
        {
            if (EventSystem.current.currentSelectedGameObject == null)
            {
                EventSystem.current.SetSelectedGameObject(lastselect);
            }
            else
            {
                lastselect = EventSystem.current.currentSelectedGameObject;
            }
        }
    }
}
