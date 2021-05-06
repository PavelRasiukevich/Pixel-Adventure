using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PixelAdventure
{
    public class LoadMenu : BaseScreen
    {
        public const string EXIT_TO_BACK_SCREEN = "EXIT_TO_BACK_SCREEN";
        public const string LOAD_CHECKPOINT_1 = "0";
      

        [SerializeField] Button[] lvlButtons;

        private void Awake()
        {
            lvlButtons = GetComponentInChildren<LayoutGroup>()
            .GetComponentsInChildren<Button>();
        }

        public override void ShowScreen()
        {
            base.ShowScreen();

        }

        public void OnBackPressed()
        {
            Exit(EXIT_TO_BACK_SCREEN);
        }

        public void SaveSlot_1()
        {
            Exit(LOAD_CHECKPOINT_1);
        }

        public void SaveSlot_2()
        {

        }

        public void SaveSlot_3()
        {

        }

    }
}
