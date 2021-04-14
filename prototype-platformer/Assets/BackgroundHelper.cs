using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PixelAdventure
{
    public class BackgroundHelper : MonoBehaviour
    {
        [SerializeField] float speed = 0;

        float pos = 0;

        RawImage rawImage;

        private void Awake()
        {
            rawImage = GetComponent<RawImage>();
        }

        private void Update()
        {
            pos += speed *Time.deltaTime;

            if (pos > 1.0F)
                pos -= 1.0F;

            rawImage.uvRect = new Rect(pos, 0, 1, 1);
        }
    }
}
