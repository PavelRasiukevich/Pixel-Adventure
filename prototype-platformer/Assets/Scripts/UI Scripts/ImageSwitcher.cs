using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PixelAdventure
{
    public class ImageSwitcher : MonoBehaviour
    {

        [SerializeField] Image prev;
        [SerializeField] Image active;
        [SerializeField] Image next;

        [SerializeField] List<Image> listOfImages;

        private void Awake()
        {
            listOfImages = new List<Image>
            {
                prev,
                active,
                next
            };
        }

        private void Update()
        {
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
        }
    }
}
