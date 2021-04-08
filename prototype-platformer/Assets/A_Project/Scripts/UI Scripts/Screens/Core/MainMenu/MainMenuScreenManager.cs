using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelAdventure
{
    public class MainMenuScreenManager : BaseScreenManager
    {
        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        protected override void Start()
        {
            base.Start();

            SetCurrentScreen<MainMenuScreen>().ShowScreen();
        }

        protected override void OnScreenExit(Type _screenType, string _exitCode)
        {
            if (_screenType == typeof(MainMenuScreen))
            {
                if (_exitCode.Equals(MainMenuScreen.EXIT_TO_GAME))
                    SceneManager.LoadScene(SceneID.START_GAME_ID);
                else if (_exitCode.Equals(MainMenuScreen.EXIT_TO_OPTIONS))
                    SetCurrentScreen<OptionsScreen>().ShowScreen();
                else if (_exitCode.Equals(MainMenuScreen.EXIT_TO_CREDITS))
                    SetCurrentScreen<CreditsScreen>().ShowScreen();
            }
            else if (_screenType == typeof(OptionsScreen))
            {
                if (_exitCode.Equals(OptionsScreen.EXIT_TO_BACK_SCREEN))
                    ToBackScreen();
            }
            else if (_screenType == typeof(CreditsScreen))
            {
                if (_exitCode.Equals(CreditsScreen.EXIT_TO_BACK_SCREEN))
                    ToBackScreen();
            }
        }
    }
}
