using PixelAdventure.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class NinjaFrogController : MonoBehaviour, IControllable
    {
        private readonly int INT_STATE = Animator.StringToHash("State");

        #region Variables
        [SerializeField] LayerMask groundLayerMask;
        [SerializeField] float speed;
        [SerializeField] float jumpForce;
        #endregion

        #region Components
        private Rigidbody2D frogRigidBody;
        private Animator frogAnimator;
        private BoxCollider2D frogBoxCollider2D;
        private SpriteRenderer frogSpriteRenderer;
        #endregion

        #region States
        private NinjaBaseState currentState;
        private Dictionary<StatesEnum, NinjaBaseState> dictionaryOfStates;
        private StatesEnum state;
        #endregion

        #region Properties
        public Rigidbody2D FrogRigidBody { get => frogRigidBody; }
        public Dictionary<StatesEnum, NinjaBaseState> DictionaryOfStates { get => dictionaryOfStates; }

        public StatesEnum State
        {
            get => state;

            set
            {
                frogAnimator.SetInteger(INT_STATE, (int)value);
            }
        }

        public bool IsGrounded
        {
            get
            {
                // return frogRigidBody.GetContacts(contactFilterGround, contacts) > 0;
                return Physics2D.BoxCast(frogBoxCollider2D.bounds.center, frogBoxCollider2D.bounds.size,
                    0, Vector2.down, .1f, groundLayerMask);
            }

        }

        public float Speed { get => speed; set => speed = value; }
        public float JumpForce { get => jumpForce; set => jumpForce = value; }
        public BoxCollider2D FrogBoxCollider2D { get => frogBoxCollider2D; set => frogBoxCollider2D = value; }
        public SpriteRenderer FrogSpriteRenderer { get => frogSpriteRenderer; set => frogSpriteRenderer = value; }
        #endregion

        private void Awake()
        {

            dictionaryOfStates = new Dictionary<StatesEnum, NinjaBaseState>()
            {
                { StatesEnum.Idle, new NinjaStateIdle() },
                { StatesEnum.Move, new NinjaStateMove() },
                { StatesEnum.Jump, new NinjaStateJump() },
            };

            frogRigidBody = GetComponent<Rigidbody2D>();
            frogAnimator = GetComponent<Animator>();
            frogBoxCollider2D = GetComponent<BoxCollider2D>();
            frogSpriteRenderer = GetComponent<SpriteRenderer>();

        }

        private void OnEnable()
        {
            EventBrocker.CallOnPlayerEnable(transform);
        }

        private void OnDisable()
        {

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

        public void TransitionToState(NinjaBaseState state)
        {
            currentState = state;
            currentState.EntryState(this);
        }

    }
}
