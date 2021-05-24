using PixelAdventure.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] float followSpeed;
        [SerializeField] Vector3 offset;
        [SerializeField] Vector2 vectorMin, vectorMax;

        public Transform target;

        void OnEnable()
        {
            target.GetComponentInParent<BaseController>().ChangeCameraBound = SwitchBound;
        }

        private void SwitchBound(CameraBoundValues _struct)
        {
            vectorMin.x = _struct.MinX;
            vectorMin.y = _struct.MinY;
            vectorMax.x = _struct.MaxX;
            vectorMax.y = _struct.MaxY;
        }

        private void LateUpdate()
        {
            Vector3 smoothPosition = Vector3.Lerp(transform.position, target.position + offset, followSpeed * Time.deltaTime);
            smoothPosition.x = Mathf.Clamp(smoothPosition.x, vectorMin.x, vectorMax.x);
            smoothPosition.y = Mathf.Clamp(smoothPosition.y, vectorMin.y, vectorMax.y);
            transform.position = smoothPosition;
        }

        public void SetTargetToFollow(Transform transform)
        {
            target = transform;
        }
    }
}
