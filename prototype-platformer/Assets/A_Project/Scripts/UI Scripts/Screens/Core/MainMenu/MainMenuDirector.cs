using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PixelAdventure
{
    public class MainMenuDirector : SceneDirector
    {
        [SerializeField] Button[] lvlButtons;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            lvlButtons = GetComponentInChildren<LevelMapScreen>(true).GetComponentInChildren<LayoutGroup>(true)
                .GetComponentsInChildren<Button>(true);
        }

        protected override void Start()
        {
            base.Start();
            SetCurrentScreen<MainMenuScreen>().ShowScreen();

            for (int i = 0; i < lvlButtons.Length; i++)
            {
                if (GameInfo.Instance.GetLevelState(i) == LevelState.Locked)
                    lvlButtons[i].interactable = false;
                else
                    lvlButtons[i].interactable = true;
            }
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
                else if (_exitCode.Equals(MainMenuScreen.EXIT_FROM_APP))
                    Application.Quit();
                else if (_exitCode.Equals(MainMenuScreen.EXIT_TO_MAP))
                    SetCurrentScreen<LevelMapScreen>().ShowScreen();
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
            else if (_screenType == typeof(LevelMapScreen))
            {
                if (_exitCode.Equals(LevelMapScreen.EXIT_TO_BACK_SCREEN))
                    ToBackScreen();
                else if (_exitCode.Equals(LevelMapScreen.EXIT_TO_INITIAL_DUNGEON))
                    SceneManager.LoadScene(SceneID.START_GAME_ID);
                else if (_exitCode.Equals(LevelMapScreen.EXIT_TO_DUNGEON_1))
                    SceneManager.LoadScene(SceneID.DUNG_1_ID);
                else if (_exitCode.Equals(LevelMapScreen.EXIT_TO_DUNGEON_2))
                    SceneManager.LoadScene(SceneID.DUNG_2_ID);
                else if (_exitCode.Equals(LevelMapScreen.EXIT_TO_DUNGEON_3))
                    SceneManager.LoadScene(SceneID.DUNG_3_ID);
                else if (_exitCode.Equals(LevelMapScreen.EXIT_TO_CAVE))
                    SceneManager.LoadScene(SceneID.CAVE_ID);
                else if (_exitCode.Equals(LevelMapScreen.EXIT_TO_TOWER))
                    SceneManager.LoadScene(SceneID.TOWER_ID);
                else if (_exitCode.Equals(LevelMapScreen.EXIT_TO_FOREST))
                    SceneManager.LoadScene(SceneID.FOREST_ID);
            }
        }
    }
}
