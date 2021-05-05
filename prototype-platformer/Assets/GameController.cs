using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] BasePowerUp[] powerUps;
        [SerializeField] int test;

        private void Awake()
        {
            powerUps = FindObjectsOfType<BasePowerUp>();

            for (int i = 0; i < powerUps.Length; i++)
            {
                if (GameInfo.Instance.GetPowerUpState(i) == PowerUpStates.Avaliable)
                {
                    powerUps[i].Index = i;
                    powerUps[i].gameObject.SetActive(true);
                }
                else
                {
                    powerUps[i].Index = i;
                    powerUps[i].gameObject.SetActive(false);
                }
            }
        }
    }
}
