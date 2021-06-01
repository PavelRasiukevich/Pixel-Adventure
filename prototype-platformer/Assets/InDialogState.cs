using System;
using UnityEngine;

namespace PixelAdventure
{
    public class InDialogState : BaseState
    {

        public Action SkipFrase { get; set; }

        public override CharacterState State => CharacterState.Dialog;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
                SkipFrase.Invoke();
        }

        public override void ActivateState()
        {
            base.ActivateState();
        }
    }
}
