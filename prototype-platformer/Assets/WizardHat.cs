namespace PixelAdventure
{
    public class WizardHat : Item
    {
        private void Awake()
        {
            ItemAbilityName = Values.DASH;
        }

        public override void ApplyAbility()
        {
            GameInfo.Instance.CharData.HasDash = true;
        }

        public override void LoseAbility()
        {
            base.LoseAbility();
        }
    }
}
