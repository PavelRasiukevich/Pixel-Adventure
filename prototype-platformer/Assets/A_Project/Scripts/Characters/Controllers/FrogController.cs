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

        private new void Awake()
        {
            base.Awake();
            transform.position = GameInfo.Instance.UserData.PlayerSpawnPosition;
            frogMove = listOfStates.Find(_s => _s.State.Equals(CharacterState.Move)) as FrogMove;
            frogFastFall = listOfStates.Find(_s => _s.State.Equals(CharacterState.FastFall)) as FrogFastFall;
        }

        private new void OnEnable()
        {
            base.OnEnable();
            frogMove.PlayerUsedDash = OnDashPlayerHandler;
            frogFastFall.FastFallUsed = OnFastFallPlayerHandler;
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

        private new void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);

            var _powerUp = collision.GetComponent<IPowerUp>();

            if (_powerUp != null)
            {
                _powerUp.AddBonusValue();
                GetRewardPoints.Invoke();
            }
        }
    }
}
