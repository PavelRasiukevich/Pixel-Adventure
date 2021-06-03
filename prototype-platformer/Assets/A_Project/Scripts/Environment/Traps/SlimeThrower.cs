using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class SlimeThrower : MonoBehaviour
    {
        [SerializeField] GameObject slimePrefab;
        [SerializeField] float repeatRate;
        [SerializeField] float throwForce;

        private void Awake()
        {
            InvokeRepeating("ThrowSlime", 0.0f, repeatRate);
        }

        private void ThrowSlime()
        {
            var _slime = Instantiate(slimePrefab).GetComponent<SlimeProjectile>();
            _slime.SetPosition(transform.position);
            _slime.AddForce(throwForce);
        }
    }
}
