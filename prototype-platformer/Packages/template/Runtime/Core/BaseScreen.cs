using System;
using UnityEngine;

namespace PixelAdventure
{
    public abstract class BaseScreen : MonoBehaviour
    {
        public bool IsShow => gameObject.activeSelf;

        public Action<Type, string> OnExitAction;

        public void Init(Action<Type, string> _exitAction)
        {
            OnExitAction = _exitAction;
        }

        protected virtual void Exit(string _exitCode)
        {
            OnExitAction.Invoke(GetType(), _exitCode);
        }

        public virtual void ShowScreen()
        {
            gameObject.SetActive(true);
        }

        public virtual void HideScreen()
        {
            gameObject.SetActive(false);
        }
    }
}
