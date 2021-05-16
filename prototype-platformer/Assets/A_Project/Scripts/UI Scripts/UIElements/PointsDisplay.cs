using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PixelAdventure
{
    public class PointsDisplay : MonoBehaviour
    {
        [SerializeField] float speed;

        private void Update()
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
    }
}
