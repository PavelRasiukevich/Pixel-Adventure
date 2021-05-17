using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class Trampoline : MonoBehaviour
    {
        Animator anim; 

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            anim.SetTrigger("Contact");
        }
    }
}
