using UnityEngine;

namespace PixelAdventure
{
    public class NPC : MonoBehaviour
    {
        [SerializeField] FraseSet_SO dialog;
        [SerializeField] string npcName;
        [SerializeField] Canvas display;

        public FraseSet_SO Dialog { get => dialog;}
        public string NpcName { get => npcName; }
        public Canvas Display { get => display;  }

        public void ShowDisplay()
        {
            display.gameObject.SetActive(true);
        }

        public void HideDisplay()
        {
            display.gameObject.SetActive(false);
        }
    }
}
