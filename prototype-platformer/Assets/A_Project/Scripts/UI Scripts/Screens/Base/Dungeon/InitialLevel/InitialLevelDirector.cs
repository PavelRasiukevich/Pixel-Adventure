using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelAdventure
{
    public class InitialLevelDirector : SceneDirector
    {
        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        protected override void Start()
        {
            base.Start();
            SetCurrentScreen<DungeonGameScreen>().ShowScreen();
            GameInfo.Instance.SetLevelState(SceneManager.GetActiveScene().buildIndex - 1, LevelState.Unlocked);
        }

        protected override void OnScreenExit(Type _screenType, string _exitCode)
        {
            if (_screenType == typeof(DungeonGameScreen))
            {
                if (_exitCode.Equals(DungeonGameScreen.EXIT_TO_MENU))
                    SetCurrentScreen<InGameMenuScreen>().ShowScreen();
                else if (_exitCode.Equals(DungeonGameScreen.EXIT_TO_NEXT_LVL))
                {
                    GameInfo.Instance.SetLevelState(SceneManager.GetActiveScene().buildIndex, LevelState.Unlocked);
                    SceneManager.LoadScene(SceneID.DUNG_1_ID);
                }
                else if (_exitCode.Equals(DungeonGameScreen.EXIT_TO_GAMEOVER))
                    SceneManager.LoadScene(SceneID.GAMEOVE_ID);

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
                    ToBackScreen();
            }
        }
    }
}
