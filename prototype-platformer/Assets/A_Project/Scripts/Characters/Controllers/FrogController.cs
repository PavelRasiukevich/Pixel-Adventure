using PixelAdventure.Interfaces;
using System;
using System.Collections;
using UnityEngine;

namespace PixelAdventure
{
    public class FrogController : BaseController
    {
        FrogMove frogMove;
        FrogFastFall frogFastFall;
        FrogDoubleJump frogDoubleJump;

        private new void Awake()
        {
            base.Awake();
            transform.position = GameInfo.Instance.GetPositionBySavePointId();
            frogMove = listOfStates.Find(_s => _s.State.Equals(CharacterState.Move)) as FrogMove;
            frogFastFall = listOfStates.Find(_s => _s.State.Equals(CharacterState.FastFall)) as FrogFastFall;
            frogDoubleJump = listOfStates.Find(_s => _s.State.Equals(CharacterState.DoubleJump)) as FrogDoubleJump;
        }

        private new void OnEnable()
        {
            base.OnEnable();
            frogMove.PlayerUsedDash = OnDashPlayerHandler;
            frogFastFall.FastFallUsed = OnFastFallPlayerHandler;
            frogDoubleJump.DoubleJumpUsed = OnDoubleJumpPlayerHandler;
        }

        private void OnDashPlayerHandler()
        {
            GameInfo.Instance.CharData.HasReloadedDash = false;
            StartCoroutine(ReloadDash());
            DashHandled.Invoke();
        }

        private IEnumerator ReloadDash()
        {
            yield return new WaitForSeconds(GameInfo.Instance.CharData.DashReloadTime);
            GameInfo.Instance.CharData.HasReloadedDash = true;
        }

        private void OnFastFallPlayerHandler()
        {
            GameInfo.Instance.CharData.HasReloadedFastFall = false;
            StartCoroutine(ReloadFastFall());
            FastFallHandled.Invoke();
        }

        private IEnumerator ReloadFastFall()
        {
            yield return new WaitForSeconds(GameInfo.Instance.CharData.FastFallReloadTime);
            GameInfo.Instance.CharData.HasReloadedFastFall = true;
        }

        private void OnDoubleJumpPlayerHandler()
        {
            GameInfo.Instance.CharData.HasReloadedDoubleJump = false;
            StartCoroutine(ReloadDoubleJump());
            DoubleJumpHandled.Invoke();
        }

        private IEnumerator ReloadDoubleJump()
        {
            yield return new WaitForSeconds(GameInfo.Instance.CharData.DoubleJumpReloadTime);
            GameInfo.Instance.CharData.HasReloadedDoubleJump = true;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var _trampoline = collision.gameObject.GetComponent<Trampoline>();

            if (_trampoline)
            {
                OnNextStateRequest(CharacterState.TrampolineJump);
            }
        }

        private new void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);

            var _powerUp = collision.GetComponent<IPowerUp>();

            if (_powerUp != null)
            {
                _powerUp.AddBonusValue();
                GetRewardPoints.Invoke();
                PowerUpConsumed.Invoke(_powerUp.GetName);
            }
        }
    }
}
