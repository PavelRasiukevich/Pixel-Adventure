using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PixelAdventure
{
    public class MainMenuDirector : SceneDirector
    {

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            GameInfo.Instance.LifeAmount = 3;
        }

        protected override void Start()
        {
            base.Start();
            SetCurrentScreen<MainMenuScreen>().ShowScreen();

            AudioManager.Instance.PlayMusic();
        }

        protected override void OnScreenExit(Type _screenType, string _exitCode)
        {
            if (_screenType == typeof(MainMenuScreen))
            {
                if (_exitCode.Equals(MainMenuScreen.EXIT_TO_GAME))
                {
                    GameInfo.Instance.NewGameSetup();
                    SceneManager.LoadScene(SceneID.START_GAME_ID);
                }
                else if (_exitCode.Equals(MainMenuScreen.EXIT_TO_OPTIONS))
                    SetCurrentScreen<OptionsScreen>().ShowScreen();
                else if (_exitCode.Equals(MainMenuScreen.EXIT_TO_CREDITS))
                    SetCurrentScreen<CreditsScreen>().ShowScreen();
                else if (_exitCode.Equals(MainMenuScreen.EXIT_FROM_APP))
                    Application.Quit();
                else if (_exitCode.Equals(MainMenuScreen.LOAD_GAME))
                {
                    GameInfo.Instance.LoadGameProgress();
                    SceneManager.LoadScene(SceneID.START_GAME_ID);
                }
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
