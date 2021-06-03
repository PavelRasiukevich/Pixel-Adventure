using TMPro;
using UnityEngine;

namespace PixelAdventure
{
    public class DialogScreen : BaseScreen
    {
        public const string EXIT_TO_GAMESCREEN = "EXIT_TO_GAMESCREEN";
        public const string EXIT_TO_END = "EXIT_TO_END";

        [SerializeField] TextMeshProUGUI text;
        [SerializeField] BaseController character;
        [SerializeField] int index;
        [SerializeField] int dialogsIndex;

        public override void ShowScreen()
        {
            base.ShowScreen();
            dialogsIndex = character.Npc.D_Index;
            text.text = $"{character.Npc.Dialogs[dialogsIndex].Frases[index]}";
        }

        private void OnEnable()
        {
            character.NextFrase = OnNextFraseHandler;
        }

        private void OnNextFraseHandler()
        {
            index++;

            if (index < character.Npc.Dialogs[dialogsIndex].Frases.Count)
                text.text = $"{$"{character.Npc.Dialogs[dialogsIndex].Frases[index]}"}";
            else
                Reset();
        }

        private void Reset()
        {
            if (dialogsIndex < character.Npc.Dialogs.Count - 1)
            {
                dialogsIndex++;
                character.Npc.D_Index = dialogsIndex;
            }

            if (character.Npc.NpcName.Equals("Astroguy"))
            {
                LastWords();
            }
            else
            {
                index = 0;
                var _c = character as FrogController;
                _c.CanSpeakWithNPC = true;
                character.Npc.ShowDisplay();
                character.OnNextStateRequest(CharacterState.Idle);
                Exit(EXIT_TO_GAMESCREEN);
            }
        }

        private void LastWords()
        {
            Exit(EXIT_TO_END);
        }
    }
}
