using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PixelAdventure
{
    public class ButtonBhv : MonoBehaviour, ISelectHandler, IDeselectHandler
    {
        private TextMeshProUGUI textTMP;
       
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
