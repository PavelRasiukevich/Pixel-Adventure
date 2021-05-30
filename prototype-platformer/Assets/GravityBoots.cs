namespace PixelAdventure
{
    public class GravityBoots : Item
    {
        private void Awake()
        {
            ItemAbilityName = Values.FASTFALL;
        }

        public override void ApplyAbility()
        {
            GameInfo.Instance.CharData.HasFastFall = true;
        }

        public override void LoseAbility()
        {
            GameInfo.Instance.CharData.HasFastFall = false;
        }
    }
}
