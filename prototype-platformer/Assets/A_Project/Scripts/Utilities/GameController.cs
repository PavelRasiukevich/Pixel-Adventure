using UnityEngine;

namespace PixelAdventure
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] Transform container;

        private void Awake()
        {
            for (int i = 0; i < container.childCount; i++)
            {
                var _powerUp = container.GetChild(i).GetComponent<BasePowerUp>();

                if (GameInfo.Instance.GetPowerUpState(i) == PowerUpStates.Avaliable)
                {
                    _powerUp.Index = i;
                    _powerUp.ActivatePowerUp(true);
                }
                else
                {
                    _powerUp.Index = i;
                    _powerUp.ActivatePowerUp(false);
                }
            }
        }
    }
}
