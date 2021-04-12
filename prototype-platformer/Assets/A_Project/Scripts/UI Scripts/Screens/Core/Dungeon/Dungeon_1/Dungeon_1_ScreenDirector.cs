using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelAdventure
{
    public class Dungeon_1_ScreenDirector : SceneDirector
    {
        protected override void Start()
        {
            base.Start();
            SetCurrentScreen<DungeonGameScreen>().ShowScreen();
        }

        protected override void OnScreenExit(Type _screenType, string _exitCode)
        {
            if (_screenType == typeof(DungeonGameScreen))
            {
                if (_exitCode.Equals(DungeonGameScreen.EXIT_TO_MENU))
                    SetCurrentScreen<InGameMenuScreen>().ShowScreen();
            }
            else if (_screenType == typeof(InGameMenuScreen))
            {
                if (_exitCode.Equals(InGameMenuScreen.EXIT_TO_BACK_SCREEN))
                    ToBackScreen();
                else if (_exitCode.Equals(InGameMenuScreen.EXIT_TO_OPTIONS))
                    SetCurrentScreen<OptionsScreen>().ShowScreen();
                else if (_exitCode.Equals(InGameMenuScreen.EXIT_TO_MAIN_MENU))
                    SceneManager.LoadScene(SceneID.MAIN_MENU_ID);
                else if (_exitCode.Equals(InGameMenuScreen.EXIT_FROM_APP))
                    Application.Quit();
            }
            else if (_screenType == typeof(OptionsScreen))
            {
                if (_exitCode.Equals(OptionsScreen.EXIT_TO_BACK_SCREEN))
                    SetCurrentScreen<DungeonGameScreen>().ShowScreen();
            }
        }
    }
}
