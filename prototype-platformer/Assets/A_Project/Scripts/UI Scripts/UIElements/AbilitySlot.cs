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

        private void Awake()
        {
            VisualizeAbilitySlotContent();
        }

        public void SetupAbilitySlot(Sprite _spr, string _name, bool _value)
        {
            IsEmpty = _value;
            fillImg.sprite = _spr;
            backImg.sprite = _spr;
            name = _name;
        }

        public void VisualizeAbilitySlotContent()
        {
            if (isEmpty)
                HideContent();
            else
                ShowContent();
        }

        private void HideContent()
        {
            var _fillColor = fillImg.color;
            _fillColor.a = 0;
            fillImg.color = _fillColor;

            var _backColor = backImg.color;
            _backColor.a = 0;
            backImg.color = _backColor;
        }

        private void ShowContent()
        {
            var _fillColor = fillImg.color;
            _fillColor.a = 255;
            fillImg.color = _fillColor;

            var _backColor = backImg.color;
            _backColor.a = 255;
            backImg.color = _backColor;
        }

        public void SetPropsToDataManager()
        {
            GameInfo.Instance.AbilitySlotData.ListOfSprites[index] = fillImg.sprite;
            GameInfo.Instance.AbilitySlotData.ListOfValues[index] = IsEmpty;
            GameInfo.Instance.AbilitySlotData.ListOfNames[index] = name;
        }
    }
}
