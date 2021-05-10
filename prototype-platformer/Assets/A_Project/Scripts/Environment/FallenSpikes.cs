using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class FallenSpikes : MonoBehaviour
    {
        Rigidbody2D rb;

        public Rigidbody2D Rb { get => rb; }

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Static;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<Transform>())
                Destroy(gameObject);
        }
    }
}
