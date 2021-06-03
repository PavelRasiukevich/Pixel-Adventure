using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public abstract class State
    {
        protected StateMachine stateMachine;
        protected Bat bat;
         
        protected State(Bat _bat, StateMachine _stateMachine)
        {
            bat = _bat;
            stateMachine = _stateMachine;
        }

        public virtual void Enter()
        {
        }

        public virtual void HandleInput()
        {
        }

        public virtual void LogicUpdate()
        {
        }

        public virtual void PhysicsUpdate()
        {
        }

        public virtual void Exit()
        {
        }
    }
}
