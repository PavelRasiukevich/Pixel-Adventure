using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PixelAdventure
{
    public class DialogScreen : BaseScreen
    {
        public const string EXIT_TO_GAMESCREEN = "EXIT_TO_GAMESCREEN";

        [SerializeField] TextMeshProUGUI text;
        [SerializeField] BaseController character;
        [SerializeField] int index;

        public override void ShowScreen()
        {
            base.ShowScreen();
            text.text = character.Npc.Dialog.Frases[index];
        }

        private void OnEnable()
        {
            character.NextFrase = OnNextFraseHandler;
        }

        private void OnNextFraseHandler()
        {
            index++;

            if (index < character.Npc.Dialog.Frases.Count)
                text.text = character.Npc.Dialog.Frases[index];
            else
                Reset();
        }

        private void Reset()
        {
            index = 0;
            character.OnNextStateRequest(CharacterState.Idle);
            Exit(EXIT_TO_GAMESCREEN);
        }
    }
}
