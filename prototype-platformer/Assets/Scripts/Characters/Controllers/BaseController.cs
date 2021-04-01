using PixelAdventure.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public abstract class BaseController : MonoBehaviour, IControllable
    {
        protected Rigidbody2D charRb;
        protected Animator charAnim;
        protected SpriteRenderer charSr;
        protected BoxCollider2D charBoxCollider;

        protected List<BaseState> listOfStates;
        protected BaseState currentState;

        public Action<Transform> OnChangePosition { get; set; }
        public Action<Transform> OnPlayerEnable { get; set; }

        private void Awake()
        {
            charRb = GetComponent<Rigidbody2D>();
            charBoxCollider = GetComponentInChildren<BoxCollider2D>();
            charAnim = GetComponentInChildren<Animator>();
            charSr = GetComponentInChildren<SpriteRenderer>();

            listOfStates = new List<BaseState>(transform.GetComponentsInChildren<BaseState>(true));

            listOfStates.ForEach(_state =>
            {
                _state.Setup(charRb, charAnim, charSr, charBoxCollider);
            });
        }

        private void OnEnable()
        {
            OnPlayerEnable?.Invoke(transform);

            listOfStates.ForEach(_state =>
            {
                _state.NextStateAction += OnNextStateRequest;
            });

            currentState = listOfStates.Find(_s => _s.State.Equals(StatesEnum.Idle));
            currentState.ActivateState();

        }

        private void OnDisable()
        {
            charRb.velocity = Vector2.zero;
            currentState.DeactivateState();

            listOfStates.ForEach(_state =>
            {
                _state.SetupRb(charRb);
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
