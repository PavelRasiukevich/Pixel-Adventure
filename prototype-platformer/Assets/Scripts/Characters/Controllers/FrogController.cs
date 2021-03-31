using System.Collections.Generic;
using UnityEngine;
using PixelAdventure.Interfaces;
using System;

namespace PixelAdventure
{
    public class FrogController : MonoBehaviour, IControllable
    {
        private Rigidbody2D frogRigidBody;
        private Animator frogAnimator;
        private SpriteRenderer frogSpriteRenderer;
        private BoxCollider2D frogBoxCollider;

        private List<BaseState> listOfStates;
        private BaseState currentState;
        private BaseState initialState;

        public Action<Transform> OnChangePosition { get; set; }

        private void Awake()
        {
            frogRigidBody = GetComponent<Rigidbody2D>();
            frogBoxCollider = GetComponentInChildren<BoxCollider2D>();
            frogAnimator = GetComponentInChildren<Animator>();
            frogSpriteRenderer = GetComponentInChildren<SpriteRenderer>();

            listOfStates = new List<BaseState>(transform.GetComponentsInChildren<BaseState>(true));

            listOfStates.ForEach(_state =>
            {
                _state.Setup(frogRigidBody, frogAnimator, frogSpriteRenderer, frogBoxCollider);
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
            frogRigidBody.velocity = Vector2.zero;
            currentState.DeactivateState();

            listOfStates.ForEach(_state =>
            {
                _state.SetupRb(frogRigidBody);
                _state.NextStateAction -= OnNextStateRequest;
            });
        }

        void FixedUpdate()
        {
            OnChangePosition?.Invoke(transform);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            currentState.OnCollision(collision);
        }

        void OnNextStateRequest(StatesEnum state)
        {
            currentState.DeactivateState();
            currentState = listOfStates.Find(_s => _s.State.Equals(state));
            currentState.ActivateState();
        }
    }
}
