using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PixelAdventure
{
    public class GameDirector : SceneDirector
    {

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void OnEnable()
        {

        }

        protected override void Start()
        {
            base.Start();
            SetCurrentScreen<GameScreen>().ShowScreen();
            GameInfo.Instance.HasTransited = false;
        }

        protected override void OnScreenExit(Type _screenType, string _exitCode)
        {
            if (_screenType == typeof(GameScreen))
            {
                if (_exitCode.Equals(GameScreen.EXIT_TO_MENU))
                    SetCurrentScreen<InGameMenuScreen>().ShowScreen();
                else if (_exitCode.Equals(GameScreen.EXIT_TO_GAMEOVER))
                    SetCurrentScreen<GameOverScreen>().ShowScreen();

            }
            else if (_screenType == typeof(InGameMenuScreen))
            {
                if (_exitCode.Equals(InGameMenuScreen.EXIT_TO_BACK_SCREEN))
                    ToBackScreen();
                else if (_exitCode.Equals(InGameMenuScreen.EXIT_TO_OPTIONS))
                    SetCurrentScreen<OptionsScreen>().ShowScreen();
                else if (_exitCode.Equals(InGameMenuScreen.EXIT_TO_MAIN_MENU))
                {
                    Time.timeScale = 1;
                    if (!GameInfo.Instance.HasTransited)
                    {
                        TransitionManager.Instance.ApplyTransition(SceneID.MAIN_MENU_ID);
                        GameInfo.Instance.HasTransited = true;
                    }
                }
                else if (_exitCode.Equals(InGameMenuScreen.EXIT_FROM_APP))
                    Application.Quit();
            }
            else if (_screenType == typeof(OptionsScreen))
            {
                if (_exitCode.Equals(OptionsScreen.EXIT_TO_BACK_SCREEN))
                    ToBackScreen();
            }
            else if (_screenType == typeof(GameOverScreen))
            {
                if (_exitCode.Equals(GameOverScreen.EXIT_TO_MAIN_MENU))
                {
                    Time.timeScale = 1;

                    if (!GameInfo.Instance.HasTransited)
                    {
                        TransitionManager.Instance.ApplyTransition(SceneID.MAIN_MENU_ID);
                        GameInfo.Instance.HasTransited = true;
                    }

                }
                else if (_exitCode.Equals(GameOverScreen.RETRY))
                {
                    if (!GameInfo.Instance.HasTransited)
                    {
                        GameInfo.Instance.Retry();
                        TransitionManager.Instance.ApplyTransition(SceneID.START_GAME_ID);
                        GameInfo.Instance.HasTransited = true;
                    }
                }
            }
        }
    }
}
