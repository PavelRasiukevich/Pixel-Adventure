using PixelAdventure.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] float followSpeed;
        [SerializeField] Vector3 offset;
        [SerializeField] float minClamp_X, maxClamp_X, minClamp_Y, maxClamp_Y;

        public Transform target;

        private void LateUpdate()
        {
            Vector3 smoothPosition = Vector3.Lerp(transform.position, target.position + offset, followSpeed * Time.deltaTime);
            smoothPosition.x = Mathf.Clamp(smoothPosition.x, minClamp_X, maxClamp_X);
            smoothPosition.y = Mathf.Clamp(smoothPosition.y, minClamp_Y, maxClamp_Y);
            transform.position = smoothPosition;
        }

        public void SetTargetToFollow(Transform transform)
        {
            target = transform;
        }
    }
}
