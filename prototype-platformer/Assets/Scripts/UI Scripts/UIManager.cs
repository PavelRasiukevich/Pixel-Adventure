using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PixelAdventure
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] List<Button> buttons;
        [SerializeField] bool mousePressed;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
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
