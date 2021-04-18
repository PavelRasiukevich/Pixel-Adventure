using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelAdventure
{
    public class GameOverDirector : SceneDirector
    {
        private void Awake()
        {
        }

        protected override void Start()
        {
            base.Start();
            SetCurrentScreen<GameOverScreen>().ShowScreen();
        }

        protected override void OnScreenExit(Type _screenType, string _exitCode)
        {
            if(_screenType == typeof(GameOverScreen))
                if(_exitCode.Equals(GameOverScreen.EXIT_TO_MAIN_MENU))
                    SceneManager.LoadScene(SceneID.MAIN_MENU_ID);
        }
    }
}
