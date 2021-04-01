using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PixelAdventure
{
    public class StartButton : MonoBehaviour
    {
        [SerializeField] Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
        }

        private void Start()
        {
            button.Select();
        }

        public void OnButtonPressed()
        {
            SceneManager.LoadScene("Game");
        }
    }
}
