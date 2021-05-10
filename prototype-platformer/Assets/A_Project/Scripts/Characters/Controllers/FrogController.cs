using PixelAdventure.Interfaces;
using System;
using System.Collections;
using UnityEngine;

namespace PixelAdventure
{
    public class FrogController : BaseController
    {
        FrogMove frogMove;

        private new void Awake()
        {
            base.Awake();
            transform.position = GameInfo.Instance.UserData.PlayerSpawnPosition;
            frogMove = listOfStates.Find(_s => _s.State.Equals(CharacterState.Move)) as FrogMove;
        }

        private new void OnEnable()
        {
            base.OnEnable();
            frogMove.PlayerUsedDash = OnDashPlayerHandler;
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
