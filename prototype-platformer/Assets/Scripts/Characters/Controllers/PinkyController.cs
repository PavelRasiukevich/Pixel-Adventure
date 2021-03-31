using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelAdventure.Interfaces;

namespace PixelAdventure
{
    public class PinkyController : MonoBehaviour, IControllable
    {
        private Rigidbody2D pinkyRigidBody;
        private Animator pinkyAnimator;
        private SpriteRenderer pinkySpriteRenderer;
        private BoxCollider2D pinkyBoxCollider;

        private List<BaseState> listOfStates;
        private BaseState currentState;

        public Action<Transform> OnChangePosition { get; set; }

        private void Awake()
        {
            pinkyRigidBody = GetComponent<Rigidbody2D>();
            pinkyAnimator = GetComponentInChildren<Animator>();
            pinkySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
            pinkyBoxCollider = GetComponentInChildren<BoxCollider2D>();

            listOfStates = new List<BaseState>(transform.GetComponentsInChildren<BaseState>(true));

            listOfStates.ForEach(_state =>
            {
                _state.Setup(pinkyRigidBody, pinkyAnimator, pinkySpriteRenderer, pinkyBoxCollider);
            });
        }

        private void OnEnable()
        {
            EventBrocker.CallOnPlayerEnable(transform);

            listOfStates.ForEach(_state =>
            {
                _state.NextStateAction += OnNextStateRequest;
            });

            currentState = listOfStates.Find(_s => _s.State.Equals(StatesEnum.Idle));
            currentState.ActivateState();
        }

        private void OnDisable()
        {
            pinkyRigidBody.velocity = Vector2.zero;
            currentState.DeactivateState();

            listOfStates.ForEach(_state =>
            {
                _state.SetupRb(pinkyRigidBody);
                _state.NextStateAction -= OnNextStateRequest;
            });
        }

        void FixedUpdate()
        {
            OnChangePosition?.Invoke(transform);
        }

        private void OnNextStateRequest(StatesEnum state)
        {
            currentState.DeactivateState();
            currentState = listOfStates.Find(_s => _s.State.Equals(state));
            currentState.ActivateState();
        }

    }
}
