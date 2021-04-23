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
        protected CapsuleCollider2D charCapsuleCollider;
        #endregion

        #region States
        protected List<BaseState> listOfStates;
        protected BaseState currentState;
        #endregion

        #region Events
        public Action<Transform> OnChangePosition { get; set; }
        public Action<Transform> OnPlayerEnable { get; set; }
        public Action OnDieActive { get; set; }
        public Action LifeLost { get; set; }
        #endregion

        #region Properties
        public Vector3 SpawnPosition { get; set; }
        #endregion

        protected void Awake()
        {
            SpawnPosition = spawn.position;

            charRb = GetComponent<Rigidbody2D>();
            charCapsuleCollider = GetComponentInChildren<CapsuleCollider2D>();
            charAnim = GetComponent<Animator>();
            charSr = GetComponentInChildren<SpriteRenderer>();

            listOfStates = new List<BaseState>(transform.GetComponentsInChildren<BaseState>(true));

            listOfStates.ForEach(_state =>
            {
                _state.Setup(charRb, charAnim, charSr, charCapsuleCollider);
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

            currentState = listOfStates.Find(_s => _s.State.Equals(CharacterState.Idle));
            currentState.ActivateState();
        }

        private void OnDieHandler()
        {
            if (!GameInfo.Instance.IsGameOverScreenAtive)
            {
                transform.position = SpawnPosition;
                charCapsuleCollider.enabled = true;
                OnNextStateRequest(CharacterState.Idle);
                charRb.bodyType = RigidbodyType2D.Dynamic;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        protected void OnDisable()
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            var obstacle = other.gameObject.GetComponent<IDamaging>();

            if (obstacle != null)
            {
                LifeLost.Invoke();
                OnNextStateRequest(CharacterState.Die);
            }
        }

        protected void OnNextStateRequest(CharacterState state)
        {
            currentState.DeactivateState();
            currentState = listOfStates.Find(_s => _s.State.Equals(state));
            Debug.Log(currentState.ToString());
            currentState.ActivateState();
        }
    }
}
