using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PixelAdventure
{
    public class ButtonBhv : MonoBehaviour, ISelectHandler, IDeselectHandler
    {
        [SerializeField] Button button;
        [SerializeField] TextMeshProUGUI textTMP;

        public Action<string> OnButtonPressedEvent;

        private void Awake()
        {
            button = GetComponent<Button>();
            textTMP = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void Start()
        {
            if (gameObject.name.Equals("Start"))
                button.Select();
        }

        public void OnButtonPressed()
        {
            OnButtonPressedEvent?.Invoke(gameObject.name);
        }

        public void OnSelect(BaseEventData eventData)
        {
            textTMP.enableVertexGradient = true;
        }

        public void OnDeselect(BaseEventData eventData)
        {
            textTMP.enableVertexGradient = false;
        }
    }
}
