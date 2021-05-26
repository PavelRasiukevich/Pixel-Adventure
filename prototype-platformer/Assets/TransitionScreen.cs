using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelAdventure
{
    public class TransitionScreen : MonoBehaviour
    {

        Animator anim;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        public void PlayAnimation(string _id)
        { 
            StartCoroutine(Fade(_id));
        }

        IEnumerator Fade(string _id)
        {
            anim.SetTrigger("Trigger");
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene(_id);
        }
    }
}
