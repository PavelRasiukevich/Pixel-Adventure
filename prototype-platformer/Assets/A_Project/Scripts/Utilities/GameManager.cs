using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PixelAdventure
{
    public class GameManager : MonoBehaviour
    {
        [Header("Characters")]
        [SerializeField] FrogController frog;
        [SerializeField] PinkyController pinky;
        [SerializeField] ShamanController sham;

        private Vector2 characterTrackedPosition;

        [SerializeField] List<BaseController> listOfCharacters;

        private int char_index;

        private void Awake()
        {
            char_index = 0;

            listOfCharacters = new List<BaseController>
            {
                frog,
                pinky,
                sham
            };
        }

        private void OnEnable()
        {
            listOfCharacters.ForEach(_char =>
            {
                _char.OnChangePosition += OnTrackPositionHandler;
                _char.OnPlayerEnable += OnPlayerEnableHandler;
            });
        }

        private void OnDisable()
        {
            listOfCharacters.ForEach(_char =>
            {
                _char.OnChangePosition -= OnTrackPositionHandler;
                _char.OnPlayerEnable -= OnPlayerEnableHandler;
            });
        }

        private void OnPlayerEnableHandler(Transform transform)
        {
            transform.position = characterTrackedPosition;
        }

        private void OnTrackPositionHandler(Transform transform)
        {
            characterTrackedPosition = transform.position;
        }

        private void Update()
        {
            #region Switch Characters
            switch (Input.inputString)
            {
                case "o":
                    if (char_index >= listOfCharacters.Count - 1)
                    {
                        listOfCharacters[listOfCharacters.Count - 1].gameObject.SetActive(false);
                        char_index = -1;
                        listOfCharacters[char_index + 1].gameObject.SetActive(true);
                    }
                    else
                    {
                        listOfCharacters[char_index + 1].gameObject.SetActive(true);
                        listOfCharacters[char_index].gameObject.SetActive(false);
                    }
                    char_index++;
                    break;
                case "i":
                    if (char_index <= 0)
                    {
                        listOfCharacters[char_index].gameObject.SetActive(false);
                        char_index = listOfCharacters.Count;
                        listOfCharacters[char_index - 1].gameObject.SetActive(true);
                    }
                    else
                    {
                        listOfCharacters[char_index].gameObject.SetActive(false);
                        listOfCharacters[char_index - 1].gameObject.SetActive(true);
                    }
                    char_index--;
                    break;
            }
            #endregion

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
