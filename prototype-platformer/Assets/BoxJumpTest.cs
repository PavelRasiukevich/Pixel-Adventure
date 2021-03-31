using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class BoxJumpTest : MonoBehaviour
    {
        [SerializeField] float jumpForce;
        [SerializeField] float jump;
        Rigidbody2D rb;
        public bool isActive;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
         
        }

        private void Update()
        {
            jump = Input.GetAxis("Jump");
            if (Input.GetKeyDown(KeyCode.Space))
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            if (isActive)
                if (rb.velocity.y < 0)
                {
                    rb.velocity += Vector2.up * Physics2D.gravity.y * 2 * Time.deltaTime;
                }
                else if (rb.velocity.y > 0 && jump <= 0)
                {
                    rb.velocity += Vector2.up * Physics2D.gravity.y * 2 * Time.deltaTime;
                }
        }
    }
}
