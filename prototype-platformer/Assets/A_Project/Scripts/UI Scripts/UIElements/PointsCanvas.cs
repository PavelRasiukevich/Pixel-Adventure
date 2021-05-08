using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PixelAdventure
{
    public class PointsCanvas : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] TextMeshProUGUI pointsText;

        public TextMeshProUGUI PointsText { get => pointsText; }

        private void Update()
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
    }
}
