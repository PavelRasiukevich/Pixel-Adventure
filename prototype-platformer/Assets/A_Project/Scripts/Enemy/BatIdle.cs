using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class BatIdle : State
    {

        public BatIdle(Bat _bat, StateMachine _stateMachine) : base(_bat, _stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            bat.BatAnim.SetInteger(bat.INT_STATE, (int)BatState.Idle);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
