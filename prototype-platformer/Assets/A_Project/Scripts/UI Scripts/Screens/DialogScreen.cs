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
            text.text = $"{character.Npc.NpcName.ChangeStringColor(ColorValues.LIGHT_PINK)}: " +
                $"{character.Npc.Dialog.Frases[index].ChangeStringColor(ColorValues.WHITE)}";
        }

        private void OnEnable()
        {
            character.NextFrase = OnNextFraseHandler;
        }

        private void OnNextFraseHandler()
        {
            index++;

            if (index < character.Npc.Dialog.Frases.Count)
                text.text = $"{character.Npc.NpcName.ChangeStringColor(ColorValues.LIGHT_PINK)}: " +
                    $"{character.Npc.Dialog.Frases[index].ChangeStringColor(ColorValues.WHITE)}";
            else
                Reset();
        }

        private void Reset()
        {
            index = 0;
            var _c = character as FrogController;
            _c.CanSpeakWithNPC = true;
            character.Npc.ShowDisplay();
            character.OnNextStateRequest(CharacterState.Idle);
            Exit(EXIT_TO_GAMESCREEN);
        }
    }
}
