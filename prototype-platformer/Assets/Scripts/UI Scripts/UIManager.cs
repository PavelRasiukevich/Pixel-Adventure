using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PixelAdventure
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] List<Button> buttons;
        [SerializeField] List<ButtonBhv> bhv;
        [SerializeField] bool mousePressed;

        private void Awake()
        {
            foreach (var b in bhv)
            {
                b.OnButtonPressedEvent += OnButtonPressedHandler;
            }

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void OnButtonPressedHandler(string name)
        {
            switch (name)
            {
                case "Start":
                    SceneManager.LoadScene("Game");
                    break;
            }
        }

        private void Update()
        {

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                mousePressed = true;
            }

            if (Mathf.Abs(Input.GetAxis("Vertical")) > 0)
            {
                if (mousePressed)
                {
                    buttons[0].Select();
                    mousePressed = false;
                }
            }
        }
    }
}
