using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelAdventure.Interfaces;
using System;

namespace PixelAdventure
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] FrogController frog;
        [SerializeField] PinkyController pinky;
        [SerializeField] Vector2 characterTrackedPosition;

        [SerializeField] List<IControllable> listOfCharacters;

        private void Awake()
        {
            listOfCharacters = new List<IControllable>
            {
                frog,
                pinky
            };
        }
        
        private void OnEnable()
        {
            EventBrocker.OnPlayerEnable += OnPlayerEnableHandler;

            listOfCharacters.ForEach(_char =>
            {
                _char.OnChangePosition += TrackCharacterPosition;
            });
        }

        private void OnDisable()
        {
            listOfCharacters.ForEach(_char =>
            {
                _char.OnChangePosition -= TrackCharacterPosition;
            });
        }

        private void OnPlayerEnableHandler(Transform transform)
        {
            transform.position = characterTrackedPosition;
        }

        private void TrackCharacterPosition(Transform transform)
        {
            characterTrackedPosition = transform.position;
        }

       

        private void Update()
        {
            
            if (Input.GetKeyDown(KeyCode.F))
            {
                frog.gameObject.SetActive(true);
                pinky.gameObject.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                frog.gameObject.SetActive(false);
                pinky.gameObject.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                frog.gameObject.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                frog.gameObject.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
