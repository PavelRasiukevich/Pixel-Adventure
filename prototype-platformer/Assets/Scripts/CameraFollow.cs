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
        [SerializeField] float minClamp, maxClamp;

        public Transform target;

        private void Awake()
        {
            EventBrocker.OnPlayerEnable += SetTargetToFollow;
        }

        private void Start()
        {

        }

        private void LateUpdate()
        {
            Vector3 smoothPosition = Vector3.Lerp(transform.position, target.position + offset, followSpeed * Time.deltaTime);
            smoothPosition.x = Mathf.Clamp(smoothPosition.x, minClamp, maxClamp);
            transform.position = smoothPosition;
        }

        public void SetTargetToFollow(Transform transform)
        {
            target = transform;
        }

        private void OnDestroy()
        {
            EventBrocker.OnPlayerEnable -= SetTargetToFollow;
        }

    }
}
