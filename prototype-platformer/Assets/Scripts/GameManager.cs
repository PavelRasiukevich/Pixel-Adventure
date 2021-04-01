using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelAdventure
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] FrogController frog;
        [SerializeField] PinkyController pinky;
        [SerializeField] ShamanController sham;
        [SerializeField] Vector2 characterTrackedPosition;
        [SerializeField] new CameraFollow camera;

        [SerializeField] List<BaseController> listOfCharacters;

        private void Awake()
        {
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
            camera.SetTargetToFollow(transform);
        }

        private void OnTrackPositionHandler(Transform transform)
        {
            characterTrackedPosition = transform.position;
        }

        private void Update()
        {
            switch (Input.inputString)
            {
                case "i":
                    frog.gameObject.SetActive(true);
                    pinky.gameObject.SetActive(false);
                    sham.gameObject.SetActive(false);
                    break;
                case "o":
                    frog.gameObject.SetActive(false);
                    pinky.gameObject.SetActive(true);
                    sham.gameObject.SetActive(false);
                    break;
                case "p":
                    frog.gameObject.SetActive(false);
                    pinky.gameObject.SetActive(false);
                    sham.gameObject.SetActive(true);
                    break;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
