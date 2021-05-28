using System;
using UnityEngine;

namespace PixelAdventure
{
    public class Trap : MonoBehaviour
    {
        [SerializeField] GameObject prefab;
        [SerializeField] bool isActivated;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var _player = collision.GetComponentInParent<BaseController>();

            if (_player)
            {
                if (!isActivated)
                {
                    isActivated = !isActivated;
                    ActivateTrap();
                }
            }
        }

        private void ActivateTrap()
        {
            var _obstacle = Instantiate(prefab);
            _obstacle.transform.position = transform.parent.position;
        }
    }
}
