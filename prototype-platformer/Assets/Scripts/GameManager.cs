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

        [SerializeField] Transform activeChar;

        [SerializeField] Sprite f;
        [SerializeField] Sprite p;
        [SerializeField] Sprite s;

        [SerializeField] Image prev;
        [SerializeField] Image active;
        [SerializeField] Image next;

        [SerializeField] List<Image> listOfImages;

        [SerializeField] Vector2 characterTrackedPosition;
        [SerializeField] new CameraFollow camera;

        [SerializeField] List<BaseController> listOfCharacters;

        private int char_index;
       
        private void Awake()
        {
            active.sprite = f;
            next.sprite = p;
            prev.sprite = s;

            char_index = 0;
            
            listOfImages = new List<Image>
            {
                prev,
                active,
                next
            };

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
            activeChar = transform;
            camera.SetTargetToFollow(transform);
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

            #region Switch Images
            switch (Input.inputString)
            {
                case "o":
                    Sprite _tmp = listOfImages[0].sprite;
                    listOfImages[0].sprite = listOfImages[1].sprite;
                    listOfImages[1].sprite = listOfImages[2].sprite;
                    listOfImages[2].sprite = _tmp;
                    break;
                case "i":
                    Sprite _tmp_back = listOfImages[2].sprite;
                    listOfImages[2].sprite = listOfImages[1].sprite;
                    listOfImages[1].sprite = listOfImages[0].sprite;
                    listOfImages[0].sprite = _tmp_back;
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
