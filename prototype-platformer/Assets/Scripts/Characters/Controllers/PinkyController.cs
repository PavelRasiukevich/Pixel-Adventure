using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class PinkyController : MonoBehaviour
    {
        private Rigidbody2D pinkyRigidBody;
        private Animator pinkyAnimator;
        private SpriteRenderer pinkySpriteRenderer;
        private BoxCollider2D pinkyBoxCollider;

        private List<BaseState> listOfStates;
        private BaseState currentState;

        private void Awake()
        {
            pinkyRigidBody = GetComponent<Rigidbody2D>();
            pinkyAnimator = GetComponentInChildren<Animator>();
            pinkySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
            pinkyBoxCollider = GetComponentInChildren<BoxCollider2D>();

            listOfStates = new List<BaseState>(transform.GetComponentsInChildren<BaseState>(true));
        }

        private void OnEnable()
        {
            listOfStates.ForEach(_state =>
            {
                _state.Setup(pinkyRigidBody, pinkyAnimator, pinkySpriteRenderer, pinkyBoxCollider);
                _state.NextStateAction += OnNextStateRequest;
            });

            currentState = listOfStates.Find(_s => _s.State.Equals(StatesEnum.Idle));
            currentState.ActivateState();
        }

        private void OnDisable()
        {
            pinkyRigidBody.velocity = Vector2.zero;

            listOfStates.ForEach(_state =>
            {
                _state.SetupRb(pinkyRigidBody);
                _state.NextStateAction -= OnNextStateRequest;
            });
        }

        private void OnNextStateRequest(StatesEnum state)
        {
            currentState.DeactivateState();
            currentState = listOfStates.Find(_s => _s.State.Equals(state));
            currentState.ActivateState();
        }

    }
}
