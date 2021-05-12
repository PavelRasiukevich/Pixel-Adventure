using PixelAdventure.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public abstract class BaseController : MonoBehaviour, IControllable
    {
        public readonly int INT_DIE = Animator.StringToHash("Die");

        #region
        [SerializeField] protected CharacterSoundSO characterSounds;
        #endregion

        #region Components
        private Rigidbody2D charRb;
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
        public Action GetRewardPoints { get; set; }
        public Action DashHandled { get; set; }
        public Action FastFallHandled { get; set; }
        public Action DoubleJumpHandled { get; set; }
        public Action<string> PowerUpConsumed { get; set; }
        #endregion

        #region Properties
        public Vector3 SpawnPosition { get; set; }
        public Rigidbody2D CharRb { get => charRb; }
        #endregion

        protected void Awake()
        {

            charRb = GetComponent<Rigidbody2D>();
            charCapsuleCollider = GetComponentInChildren<CapsuleCollider2D>();
            charAnim = GetComponent<Animator>();
            charSr = GetComponentInChildren<SpriteRenderer>();

            listOfStates = new List<BaseState>(transform.GetComponentsInChildren<BaseState>(true));

            listOfStates.ForEach(_state =>
            {
                _state.Setup(charRb, charAnim, charSr, charCapsuleCollider, characterSounds);
            });
        }

        protected void OnEnable()
        {

            var _listeners = charAnim.GetBehaviours<StateMachineListener>();

            foreach (var _listener in _listeners)
            {
                _listener.ExitState += OnStateExit;
            }

            OnPlayerEnable?.Invoke(transform);

            listOfStates.ForEach(_state =>
            {
                _state.NextStateAction += OnNextStateRequest;
            });

            currentState = listOfStates.Find(_s => _s.State.Equals(CharacterState.Idle));
            currentState.ActivateState();
        }

        private void OnStateExit(AnimatorStateInfo _info)
        {
            if (_info.shortNameHash == INT_DIE)
            {
                if (!GameInfo.Instance.IsGameOverScreenActive)
                {
                    transform.position = GameInfo.Instance.UserData.PlayerSpawnPosition;
                    charCapsuleCollider.enabled = true;
                    OnNextStateRequest(CharacterState.Idle);
                    charRb.bodyType = RigidbodyType2D.Dynamic;
                }
                else
                {
                    gameObject.SetActive(false);
                }
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

        protected void OnTriggerEnter2D(Collider2D other)
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
            currentState.ActivateState();
        }
    }
}
