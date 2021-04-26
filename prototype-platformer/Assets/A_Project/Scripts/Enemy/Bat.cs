using PixelAdventure.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class Bat : MonoBehaviour
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

        #region Properties
        public Animator BatAnim { get => batAnim; }
        public Transform TargetToChase { get => targetToChase; set => targetToChase = value; }
        public float Speed { get => speed; set => speed = value; }
        public Transform IdleSpot { get => idleSpot; set => idleSpot = value; }
        public BatIdle BatIdle { get => batIdle; set => batIdle = value; }
        public BatChase Chase { get => chase; set => chase = value; }
        public BatCeillingIn CeillingIn { get => ceillingIn; set => ceillingIn = value; }
        public BatCeillingOut CeillingOut { get => ceillingOut; set => ceillingOut = value; }
        #endregion

        private void Awake()
        {
            batAnim = GetComponent<Animator>();
            batAnim.GetBehaviour<CeillingOutBhv>().CeillingOutLastFrame += OnOutHandler;
            batAnim.GetBehaviour<CeillingInBhv>().CeillingInLastFrame += OnInHandler;

            machine = new StateMachine();
            batIdle = new BatIdle(this, machine);
            chase = new BatChase(this, machine);
            ceillingIn = new BatCeillingIn(this, machine);
            ceillingOut = new BatCeillingOut(this, machine);

            detectionArea.TriggerInter += OnTriggerInteredHandler;
            detectionArea.TriggerExit += OnTriggerExitHandler;
        }

        private void OnOutHandler()
        {
            machine.ChangeState(chase);
        }

        private void OnInHandler()
        {
            machine.ChangeState(BatIdle);
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
            machine.ChangeState(ceillingOut);
        }

        private void OnTriggerExitHandler()
        {
            targetToChase = idleSpot;
            #endregion
        }
    }
}
