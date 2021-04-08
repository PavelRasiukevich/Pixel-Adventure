using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelAdventure
{
    public class StartGameManager : BaseScreenManager
    {
        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        protected override void Start()
        {
            base.Start();

            SetCurrentScreen<StartGameScreen>().ShowScreen();
        }

        protected override void OnScreenExit(Type _screenType, string _exitCode)
        {
            if (_screenType == typeof(StartGameScreen))
            {
                if (_exitCode.Equals(StartGameScreen.EXIT_TO_MENU))
                    SetCurrentScreen<InGameMenuScreen>().ShowScreen();
                else if (_exitCode.Equals(StartGameScreen.EXIT_TO_NEXT_LVL))
                    SceneManager.LoadScene(SceneID.LVL_1_ID);
            }
            else if (_screenType == typeof(InGameMenuScreen))
            {
                if (_exitCode.Equals(InGameMenuScreen.EXIT_TO_BACK_SCREEN))
                    ToBackScreen();
                else if (_exitCode.Equals(InGameMenuScreen.EXIT_TO_OPTIONS))
                    SetCurrentScreen<OptionsScreen>().ShowScreen();
                else if (_exitCode.Equals(InGameMenuScreen.EXIT_TO_MAIN_MENU))
                    SceneManager.LoadScene(SceneID.MAIN_MENU_ID);
            }
            else if (_screenType == typeof(OptionsScreen))
            {
                if (_exitCode.Equals(OptionsScreen.EXIT_TO_BACK_SCREEN))
                    SetCurrentScreen<StartGameScreen>().ShowScreen();
            }
        }
    }
}
