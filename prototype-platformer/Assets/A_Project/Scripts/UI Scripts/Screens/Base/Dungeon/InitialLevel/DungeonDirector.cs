using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelAdventure
{
    public class DungeonDirector : SceneDirector
    {
        [SerializeField] LevelID id;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        protected override void Start()
        {
            base.Start();
            GameInfo.Instance.IsGameOverScreenActive = false;
            GameInfo.Instance.LevelIndex = SceneManager.GetActiveScene().buildIndex;
            SetCurrentScreen<DungeonGameScreen>().ShowScreen();
        }

        protected override void OnScreenExit(Type _screenType, string _exitCode)
        {
            if (_screenType == typeof(DungeonGameScreen))
            {
                if (_exitCode.Equals(DungeonGameScreen.EXIT_TO_MENU))
                    SetCurrentScreen<InGameMenuScreen>().ShowScreen();
                else if (_exitCode.Equals(DungeonGameScreen.EXIT_TO_NEXT_LVL))
                {
                    GameInfo.Instance.LevelComplited(GameInfo.Instance.LevelIndex);
                    SceneManager.LoadScene(id.ToString());
                }
                else if (_exitCode.Equals(DungeonGameScreen.EXIT_TO_GAMEOVER))
                    SetCurrentScreen<GameOverScreen>().ShowScreen();

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
            else if (_screenType == typeof(GameOverScreen))
            {
                if (_exitCode.Equals(GameOverScreen.EXIT_TO_MAIN_MENU))
                    SceneManager.LoadScene(SceneID.MAIN_MENU_ID);
                else if (_exitCode.Equals(GameOverScreen.RETRY))
                    SceneManager.LoadScene(GameInfo.Instance.Retry());
            }
        }
    }
}
