using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class Bridge : MonoBehaviour
    {
        [SerializeField] bool isActive;

        public bool IsActive { get => isActive; set => isActive = value; }

        public void ActivateBridge(bool _value)
        {
            IsActive = _value;
            gameObject.SetActive(_value);
        }
    }
}
