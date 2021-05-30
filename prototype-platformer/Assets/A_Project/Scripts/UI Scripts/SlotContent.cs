using UnityEngine;
using UnityEngine.UI;

namespace PixelAdventure
{
    public class SlotContent : MonoBehaviour
    {
        [SerializeField] Image itemImg;
        [SerializeField] Item item;

        public Sprite ContentSprite { get => itemImg.sprite; set => itemImg.sprite = value; }
        public Item Item { get => item; set => item = value; }

        public void ShowSlotContent()
        {
            gameObject.SetActive(true);
        }


        public void HideSlotContent()
        {
            gameObject.SetActive(false);
        }

    }
}
