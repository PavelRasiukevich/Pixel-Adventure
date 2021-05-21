using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PixelAdventure
{
    public class ButtonBhv : MonoBehaviour, ISelectHandler, IDeselectHandler
    {
        TextMeshProUGUI textTMP;

        private void Awake()
        {
            textTMP = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void OnDisable()
        {
            textTMP.enableVertexGradient = false;
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
