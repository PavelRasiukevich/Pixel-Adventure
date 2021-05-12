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
            transform.position = GameInfo.Instance.UserData.PlayerSpawnPosition;
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
            GameInfo.Instance.HasReloadedDash = false;
            StartCoroutine(ReloadDash());
            DashHandled.Invoke();
        }

        private IEnumerator ReloadDash()
        {
            yield return new WaitForSeconds(GameInfo.Instance.CharData.DashReloadTime);
            GameInfo.Instance.HasReloadedDash = true;
        }

        private void OnFastFallPlayerHandler()
        {
            GameInfo.Instance.HasReloadedFastFall = false;
            StartCoroutine(ReloadFastFall());
            FastFallHandled.Invoke();
        }

        private IEnumerator ReloadFastFall()
        {
            yield return new WaitForSeconds(GameInfo.Instance.CharData.FastFallReloadTime);
            GameInfo.Instance.HasReloadedFastFall = true;
        }

        private void OnDoubleJumpPlayerHandler()
        {
            GameInfo.Instance.HasReloadedDoubleJump = false;
            StartCoroutine(ReloadDoubleJump());
            DoubleJumpHandled.Invoke();
        }

        private IEnumerator ReloadDoubleJump()
        {
            yield return new WaitForSeconds(GameInfo.Instance.CharData.DoubleJumpReloadTime);
            GameInfo.Instance.HasReloadedDoubleJump = true;
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
