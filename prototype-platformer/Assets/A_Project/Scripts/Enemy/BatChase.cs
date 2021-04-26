using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class BatChase : State
    {
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
           
            if(Vector2.Distance(bat.transform.position, bat.TargetToChase.position) < .5f)
            {
                if(bat.TargetToChase.gameObject == bat.IdleSpot.gameObject)
                {
                    Debug.Log("!!!!!");
                    stateMachine.ChangeState(bat.CeillingIn);
                }
            }

                bat.transform.position = Vector2.MoveTowards(bat.transform.position,
                    bat.TargetToChase.position, bat.Speed * Time.deltaTime);
            
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
