using PixelAdventure.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class FallenSpikesDetectionArea : MonoBehaviour
    {

        [SerializeField] FallenSpikes spikes;

        BoxCollider2D boxCollider;

        private void Awake()
        {
            boxCollider = GetComponent<BoxCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IControllable _player = collision.GetComponentInParent<IControllable>();

            if(_player != null)
            {
                spikes.Rb.bodyType = RigidbodyType2D.Dynamic;
                boxCollider.enabled = false;
            }
        }
    }
}
