using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] PowerUpContainer powerUpsList;

        public List<BasePowerUp> List { get => powerUpsList.List; }

        private void Awake()
        {

            for (int i = 0; i < List.Count; i++)
            {
                if (GameInfo.Instance.GetPowerUpState(i) == PowerUpStates.Avaliable)
                {
                    List[i].Index = i;
                    List[i].gameObject.SetActive(true);
                }
                else
                {
                    List[i].Index = i;
                    List[i].gameObject.SetActive(false);
                }
            }
        }
    }

    [Serializable]
    public class PowerUpContainer
    {
        [SerializeField] List<BasePowerUp> list;

        public List<BasePowerUp> List { get => list; }
    }
}
