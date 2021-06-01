using UnityEngine;

namespace PixelAdventure
{
    public class PearlPowerUp : BasePowerUp
    {
        [SerializeField] int liveBonus;

        private void Awake()
        {
            name = Values.PEARL;
        }

        public override void AddBonusValue()
        {
            GameInfo.Instance.CharData.LiveAmount += liveBonus;

            PickUpPowerUp();
        }
    }
}
