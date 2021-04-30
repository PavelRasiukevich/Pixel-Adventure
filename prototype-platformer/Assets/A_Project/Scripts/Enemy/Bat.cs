using PixelAdventure.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class Bat : MonoBehaviour, IDamaging
    {
        public readonly int INT_STATE = Animator.StringToHash("State");

        #region States and Machine
        StateMachine machine;
        BatIdle batIdle;
        BatChase chase;
        BatCeillingIn ceillingIn;
        BatCeillingOut ceillingOut;
        #endregion

        [SerializeField] float speed;
        [SerializeField] DetectionArea detectionArea;
        [SerializeField] Transform idleSpot;
        [SerializeField] Transform targetToChase;

        Animator batAnim;
        SpriteRenderer batSr;

        #region Properties
        public Animator BatAnim { get => batAnim; }
        public Transform TargetToChase { get => targetToChase; set => targetToChase = value; }
        public float Speed { get => speed; set => speed = value; }
        public Transform IdleSpot { get => idleSpot; set => idleSpot = value; }
        public BatIdle BatIdle { get => batIdle; set => batIdle = value; }
        public BatChase Chase { get => chase; set => chase = value; }
        public BatCeillingIn CeillingIn { get => ceillingIn; set => ceillingIn = value; }
        public BatCeillingOut CeillingOut { get => ceillingOut; set => ceillingOut = value; }
        public SpriteRenderer BatSr { get => batSr; }
        #endregion

        private void Awake()
        {
            batAnim = GetComponent<Animator>();
            batSr = GetComponent<SpriteRenderer>();

            machine = new StateMachine();
            batIdle = new BatIdle(this, machine);
            chase = new BatChase(this, machine);
            ceillingIn = new BatCeillingIn(this, machine);
            ceillingOut = new BatCeillingOut(this, machine);

        }

        void OnEnable()
        {
            detectionArea.TriggerInter += OnTriggerInteredHandler;
            detectionArea.TriggerExit += OnTriggerExitHandler;

            var _listeners = batAnim.GetBehaviours<StateMachineListener>();

            foreach (var _listener in _listeners)
            {
                _listener.ExitState += OnStateExit;
            }
        }

        private void OnStateExit(AnimatorStateInfo _info)
        {
            if (_info.IsName("BatCeillingOut"))
            {
                machine.ChangeState(chase);
            }
            else if (_info.IsName("BatCeillingIn"))
            {
                machine.ChangeState(batIdle);
            }
        }

        private void Start()
        {
            machine.Initialize(batIdle);
        }

        private void Update()
        {
            machine.CurrentState.HandleInput();
            machine.CurrentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            machine.CurrentState.PhysicsUpdate();
        }

        #region EventHandlers
        private void OnTriggerInteredHandler(BaseController _player)
        {
            targetToChase = _player.transform;

            if (!machine.CurrentState.Equals(chase))
                machine.ChangeState(ceillingOut);
        }

        private void OnTriggerExitHandler()
        {
            targetToChase = idleSpot;
        }
        #endregion
    }
}
