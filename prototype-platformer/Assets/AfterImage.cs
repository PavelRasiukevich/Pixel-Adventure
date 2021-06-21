using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class AfterImage : MonoBehaviour
    {
        public readonly int INT_AfterImageAnimation = Animator.StringToHash("AfterImageAnimation");

        private Animator animator;
        private List<StateMachineListener> stateMachineListeners;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            stateMachineListeners = new List<StateMachineListener>();
        }

        private void OnEnable()
        {
            RegistrateListeners();
        }

        private void OnDisable()
        {
            UnregistrateListeners();
        }

        private void ExitStateHandler(AnimatorStateInfo _info)
        {
            Activate(!(_info.shortNameHash == INT_AfterImageAnimation));
        }

        private void Activate(bool _value)
        {
            gameObject.SetActive(_value);
        }

        private void RegistrateListeners()
        {
            stateMachineListeners.AddRange(animator.GetBehaviours<StateMachineListener>());

            foreach (var listener in stateMachineListeners)
            {
                listener.ExitState += ExitStateHandler;
            }
        }

        private void UnregistrateListeners()
        {
            foreach (var listener in stateMachineListeners)
            {
                listener.ExitState -= ExitStateHandler;
            }
        }
    }
}
