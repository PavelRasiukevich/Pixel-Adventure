using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class NPC : MonoBehaviour 
    {
        [SerializeField] List<FraseSet_SO> dialogs;
        [SerializeField] string npcName;
        [SerializeField] Canvas display;
        [SerializeField] bool lastWords;
        [SerializeField] int d_Index;

        BoxCollider2D col2D;
        SpriteRenderer sprRend;

        public List<FraseSet_SO> Dialogs { get => dialogs; }
        public string NpcName { get => npcName; }
        public Canvas Display { get => display; }
        public SpriteRenderer SprRend { get => sprRend; }
        public bool LastWords { get => lastWords; set => lastWords = value; }
        public int D_Index { get => d_Index; set => d_Index = value; }

        private void Awake()
        {
            col2D = GetComponent<BoxCollider2D>();
            sprRend = GetComponent<SpriteRenderer>();
        }

        public void ShowDisplay()
        {
            display.gameObject.SetActive(true);
        }

        public void HideDisplay()
        {
            display.gameObject.SetActive(false);
        }

        public void TriggerOn()
        {
            col2D.isTrigger = true;
        }

        public void TriggerOff()
        {
            col2D.isTrigger = false;
        }

        public void LookAt(Transform _target)
        {

        }
    }
}
