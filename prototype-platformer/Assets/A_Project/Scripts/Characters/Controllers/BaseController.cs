using PixelAdventure.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public abstract class BaseController : MonoBehaviour, IControllable
    {
        #region
        [SerializeField] protected Transform spawn;
        #endregion

        #region Components
        protected Rigidbody2D charRb;
        protected Animator charAnim;
        protected SpriteRenderer charSr;
        protected BoxCollider2D charBoxCollider;
        #endregion

        #region States
        protected List<BaseState> listOfStates;
        protected BaseState currentState;
        #endregion

        #region Events
        public Action<Transform> OnChangePosition { get; set; }
        public Action<Transform> OnPlayerEnable { get; set; }
        public Action OnDieActive { get; set; }
        #endregion

        protected void Awake()
        {
            charRb = GetComponent<Rigidbody2D>();
            charBoxCollider = GetComponentInChildren<BoxCollider2D>();
            charAnim = GetComponent<Animator>();
            charSr = GetComponentInChildren<SpriteRenderer>();

            listOfStates = new List<BaseState>(transform.GetComponentsInChildren<BaseState>(true));

            listOfStates.ForEach(_state =>
            {
                _state.Setup(charRb, charAnim, charSr, charBoxCollider);
            });
        }

        protected void OnEnable()
        {

            charAnim.GetBehaviour<DieBhv>().OnDied += OnDieHandler;

            OnPlayerEnable?.Invoke(transform);

            listOfStates.ForEach(_state =>
            {
                _state.NextStateAction += OnNextStateRequest;
            });

            currentState = listOfStates.Find(_s => _s.State.Equals(StatesEnum.Idle));
            currentState.ActivateState();
        }

        private void OnDieHandler()
        {
            OnNextStateRequest(StatesEnum.Idle);
            transform.position = spawn.position;
            charRb.bodyType = RigidbodyType2D.Dynamic;
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

        private void OnTriggerEnter2D(Collider2D collider)
        {
            IDamaging trap = collider.gameObject.GetComponent<IDamaging>();

            if (trap != null)
            {
                OnNextStateRequest(StatesEnum.Die);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            IDamaging trap = collision.gameObject.GetComponent<IDamaging>();

            if (trap != null)
            {
                OnNextStateRequest(StatesEnum.Die);
            }
        }

        protected void OnNextStateRequest(StatesEnum state)
        {
            currentState.DeactivateState();
            currentState = listOfStates.Find(_s => _s.State.Equals(state));
            currentState.ActivateState();
        }
    }
}
