using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class CameraSideTrigger : MonoBehaviour
    {
        public Action<string> SideTriggered { get; set; }

        private string sideName;

        [SerializeField] CameraTriggers side;

        private void Awake()
        {
            sideName = side.ToString();
        }

        private void OnTriggerExit2D(Collider2D collision)
        {

            CircleCollider2D _player = collision.GetComponentInChildren<CircleCollider2D>();

            if (_player)
            {
                StartCoroutine(ColliderTimer(_player));
                SideTriggered.Invoke(sideName);
            }
        }

        IEnumerator ColliderTimer(CircleCollider2D _collider)
        {
            Debug.Log("CORUTINE");
            _collider.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.15f);
            _collider.gameObject.SetActive(true);
        }
    }
}
