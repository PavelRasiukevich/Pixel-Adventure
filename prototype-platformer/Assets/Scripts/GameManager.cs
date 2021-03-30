using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelAdventure
{
    public class GameManager : MonoBehaviour
    {
       
        private void Awake()
        {
           
        }

        private void OnEnable()
        {
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
