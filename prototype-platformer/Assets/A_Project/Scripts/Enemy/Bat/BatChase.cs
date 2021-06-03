using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class BatChase : State
    {
        Vector3 lastPos;

        public BatChase(Bat _bat, StateMachine _stateMachine) : base(_bat, _stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            bat.BatAnim.SetInteger(bat.INT_STATE, (int)BatState.Chasing);
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
            lastPos = bat.transform.position;

            if (Vector2.Distance(bat.transform.position, bat.TargetToChase.position) < .75f)
            {
                if (bat.TargetToChase.gameObject == bat.IdleSpot.gameObject)
                {
                    stateMachine.ChangeState(bat.CeillingIn);
                }
            }
            else
            {
                bat.transform.position = Vector2.MoveTowards(bat.transform.position,
                bat.TargetToChase.position, bat.Speed * Time.deltaTime);
            }

            Vector3 _direction = (bat.transform.position - lastPos).normalized;

            if (_direction.x >= 0)
                bat.BatSr.flipX = true;
            else
                bat.BatSr.flipX = false;
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
