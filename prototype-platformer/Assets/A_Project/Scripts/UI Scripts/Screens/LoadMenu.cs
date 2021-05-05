using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PixelAdventure
{
    public class LoadMenu : BaseScreen
    {
        public const string EXIT_TO_BACK_SCREEN = "EXIT_TO_BACK_SCREEN";
      

        [SerializeField] Button[] lvlButtons;

        private void Awake()
        {
            lvlButtons = GetComponentInChildren<LayoutGroup>()
            .GetComponentsInChildren<Button>();
        }

        public override void ShowScreen()
        {
            base.ShowScreen();

            for (int i = 0; i < lvlButtons.Length; i++)
            {
                if (GameInfo.Instance.GetCheckPointState(i) == CheckPointState.Locked)
                    lvlButtons[i].interactable = false;
                else
                    lvlButtons[i].interactable = true;
            }
        }

        public void OnBackPressed()
        {
            Exit(EXIT_TO_BACK_SCREEN);
        }

        public void SaveSlot_1()
        {

        }

        public void SaveSlot_2()
        {

        }

        public void SaveSlot_3()
        {

        }

    }
}
