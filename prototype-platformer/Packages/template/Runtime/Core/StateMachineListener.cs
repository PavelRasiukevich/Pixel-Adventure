using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class StateMachineListener : StateMachineBehaviour
    {
        public Action<AnimatorStateInfo> EnterState { get; set; }
        public Action<AnimatorStateInfo> ExitState { get; set; }

     /*   public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            EnterState.Invoke(stateInfo);
        }*/

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);
            ExitState.Invoke(stateInfo);
        }
    }
}
