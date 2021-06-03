using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class StateMachine
    {
        public State CurrentState { get; private set; }

        public void Initialize(State _state)
        {
            CurrentState = _state;
            CurrentState.Enter();
        }

        public void ChangeState(State _nextState)
        {
            CurrentState.Exit();
            CurrentState = _nextState;
            CurrentState.Enter();
        }
    }
}
