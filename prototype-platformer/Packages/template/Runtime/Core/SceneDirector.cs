using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public abstract class SceneDirector : MonoBehaviour
    {
       protected Dictionary<Type, BaseScreen> screenDict;
        Stack<BaseScreen> screenStack;

        protected BaseScreen CurrentScreen { get; private set; }
        protected BaseScreen BackScreen => screenStack.Count > 0 ? screenStack.Peek() : null;

        protected abstract void OnScreenExit(Type _screenType, string _exitCode);

        protected virtual void Start()
        {
            screenDict = new Dictionary<Type, BaseScreen>();
            screenStack = new Stack<BaseScreen>();

            for (int i = 0; i < transform.childCount; i++)
            {
                var _screen = transform.GetChild(i).GetComponent<BaseScreen>();

                if (_screen)
                {
                    if (_screen.IsShow)
                        throw new Exception("Screen must be disabled");

                    screenDict.Add(_screen.GetType(), _screen);
                    _screen.Init(OnScreenExit);
                }
            }
        }

        protected T SetCurrentScreen<T>() where T : BaseScreen
        {
            BaseScreen _nextScreen = screenDict[typeof(T)];

            if (CurrentScreen)
            {
                CurrentScreen.HideScreen();

                if (BackScreen == _nextScreen)
                    screenStack.Pop();
                else
                    screenStack.Push(CurrentScreen);
            }

            CurrentScreen = _nextScreen;

            return CurrentScreen as T;
        }

        protected void ToBackScreen()
        {
            var _nextScreen = screenStack.Pop();

            CurrentScreen.HideScreen();
            CurrentScreen = _nextScreen;
            CurrentScreen.ShowScreen();
        }
    }
}
