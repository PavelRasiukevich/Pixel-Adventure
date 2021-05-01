using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class JumpBonus : BaseBonus
    {

        public override string BonusName => bonusName;

        public override float AddBonus()
        {
            return bonusValue;
        }

    }
}
