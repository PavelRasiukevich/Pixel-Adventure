using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] float rotationVelocity;

        private void Update()
        {
            transform.Rotate(Vector3.forward * 100 * Time.deltaTime);
        }
    }
}
