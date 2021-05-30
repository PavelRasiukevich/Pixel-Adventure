using UnityEngine;
using UnityEngine.UI;

namespace PixelAdventure
{
    public class AbilitySlot : MonoBehaviour
    {
        [SerializeField] bool isEmpty;
        [SerializeField] new string name;
        [SerializeField] Image fillImg;
        [SerializeField] Image backImg;

        int index;

        public int Index { get => index; set => index = value; }
        public bool IsEmpty { get => isEmpty; set => isEmpty = value; }
        public string Name { get => name; set => name = value; }
        public Image FillImg { get => fillImg; set => fillImg = value; }
        public Image BackImg { get => backImg; set => backImg = value; }


        public void SetupAbilitySlot(Sprite _spr, string _name)
        {
            IsEmpty = false;
            fillImg.sprite = _spr;
            backImg.sprite = _spr;
            name = _name;
        }

        public void SetPropsToDataManager()
        {
            GameInfo.Instance.AbilitySlotData.ListOfSprites[index] = fillImg.sprite;
            GameInfo.Instance.AbilitySlotData.ListOfValues[index] = IsEmpty;
            GameInfo.Instance.AbilitySlotData.ListOfNames[index] = name;
        }
    }
}
