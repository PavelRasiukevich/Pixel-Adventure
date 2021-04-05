using UnityEngine;

namespace PixelAdventure
{
    public class DieState : BaseState
    {
        public override StatesEnum State => StatesEnum.Die;

        public override void ActivateState()
        {
            base.ActivateState();
            characterRigidBody.velocity = Vector2.zero;
            characterRigidBody.bodyType = RigidbodyType2D.Kinematic;
        }
    }
}
