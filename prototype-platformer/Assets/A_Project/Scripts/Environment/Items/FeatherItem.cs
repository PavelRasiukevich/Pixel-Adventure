namespace PixelAdventure
{
    public class FeatherItem : Item
    {
        private void Awake()
        {
            ItemAbilityName = Values.DOUBLEJUMP;
        }

        public override void ApplyAbility()
        {
            GameInfo.Instance.CharData.HasDoubleJump = true;
        }

        public override void LoseAbility()
        {
            GameInfo.Instance.CharData.HasDoubleJump = false;
        }
    }
}
