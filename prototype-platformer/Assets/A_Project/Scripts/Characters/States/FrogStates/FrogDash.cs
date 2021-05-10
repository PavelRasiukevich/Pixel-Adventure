using UnityEngine;

namespace PixelAdventure
{
    public class FrogDash : BaseState
    {
        public override CharacterState State => CharacterState.Dash;

        public override void ActivateState()
        {
            base.ActivateState();

            var _velocity = characterRigidBody.velocity;

            if (_velocity.x > 0)
                characterRigidBody.MovePosition(characterRigidBody.position + GameInfo.Instance.CharData.DashLenght);
            if (_velocity.x < 0)
                characterRigidBody.MovePosition(characterRigidBody.position - GameInfo.Instance.CharData.DashLenght);

            NextStateAction(CharacterState.Idle);
        }
    }
}
