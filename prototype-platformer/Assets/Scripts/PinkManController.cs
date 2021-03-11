using PixelAdventure.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PinkManController : MonoBehaviour, IControllable
    {
        private readonly int INT_STATE = Animator.StringToHash("State");

        #region Variables
        [SerializeField] LayerMask groundLayerMask;
        [SerializeField] float speed;
        [SerializeField] float jumpForce;
        #endregion

        #region Components
        private Rigidbody2D pinkRigidBody;
        private Animator pinkAnimator;
        private BoxCollider2D pinkBoxCollider2D;
        private SpriteRenderer pinkSpriteRenderer;
        #endregion

        #region States
        private PinkManBaseState currentState;
        private Dictionary<StatesEnum, PinkManBaseState> dictionaryOfStates;
        private StatesEnum state;
        #endregion

        #region Properties
        public Rigidbody2D PinkRigidBody { get => pinkRigidBody; }
        public Dictionary<StatesEnum, PinkManBaseState> DictionaryOfStates { get => dictionaryOfStates; }

        public StatesEnum State
        {
            set
            {
                pinkAnimator.SetInteger(INT_STATE, (int)value);
            }
        }

        public bool IsGrounded
        {
            get
            {
                return Physics2D.BoxCast(pinkBoxCollider2D.bounds.center, pinkBoxCollider2D.bounds.size,
                    0, Vector2.down, .1f, groundLayerMask);
            }
        }

        public float Speed { get => speed; set => speed = value; }
        public float JumpForce { get => jumpForce; set => jumpForce = value; }
        public BoxCollider2D PinkBoxCollider2D { get => pinkBoxCollider2D; set => pinkBoxCollider2D = value; }
        public SpriteRenderer PinkSpriteRenderer { get => pinkSpriteRenderer; set => pinkSpriteRenderer = value; }
        #endregion

        private void Awake()
        {

            dictionaryOfStates = new Dictionary<StatesEnum, PinkManBaseState>()
            {
                { StatesEnum.Idle, new PinkManStateIdle() },
                { StatesEnum.Move, new PinkManStateMove() },
                { StatesEnum.Jump, new PinkManStateJump() },
            };

            pinkRigidBody = GetComponent<Rigidbody2D>();
            pinkAnimator = GetComponent<Animator>();
            pinkBoxCollider2D = GetComponent<BoxCollider2D>();
            pinkSpriteRenderer = GetComponent<SpriteRenderer>();

        }

        private void OnEnable()
        {
            EventBrocker.CallOnPlayerEnable(transform);
        }

        void Start()
        {
            TransitionToState(DictionaryOfStates[StatesEnum.Idle]);
        }

        private void Update()
        {
            currentState.Update(this);
        }

        private void FixedUpdate()
        {
            currentState.FixedUpdate(this);
        }

        public void TransitionToState(PinkManBaseState state)
        {
            currentState = state;
            currentState.EntryState(this);
        }

    }
}
