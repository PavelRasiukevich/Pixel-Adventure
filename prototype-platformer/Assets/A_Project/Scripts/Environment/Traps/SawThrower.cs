using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class SawThrower : MonoBehaviour
    {
        [SerializeField] GameObject prefab;
        [SerializeField] float reloadTime;
        [SerializeField] Direction direction;

        float timer;

        private void Awake()
        {
            timer = reloadTime;
        }

        private void Update()
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                var _projectile = Instantiate(prefab).GetComponent<Projectile>();
                _projectile.Move(direction);
                _projectile.transform.position = transform.position;
                _projectile.transform.rotation = Quaternion.identity;
                timer = reloadTime;
            }
        }


    }
}
