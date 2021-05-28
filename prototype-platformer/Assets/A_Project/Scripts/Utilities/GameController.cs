using UnityEngine;

namespace PixelAdventure
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] Transform powerUpContainer;
        [SerializeField] Transform itemContainer;

        private void Awake()
        {

            GameInfo.Instance.InitPowerupData(powerUpContainer.childCount);
            GameInfo.Instance.InitItemData(itemContainer.childCount);

            SetPowerUpState();
            SetItemState();
        }

        private void SetItemState()
        {
            for (int i = 0; i < itemContainer.childCount; i++)
            {
                var _item = itemContainer.GetChild(i).GetComponent<Item>();

                if (GameInfo.Instance.GetItemState(i) == ItemState.Avaliable)
                {
                    _item.Index = i;
                    _item.On();
                }
                else
                {
                    _item.Index = i;
                    _item.Off();
                }
            }
        }

        private void SetPowerUpState()
        {
            for (int i = 0; i < powerUpContainer.childCount; i++)
            {
                var _powerUp = powerUpContainer.GetChild(i).GetComponent<BasePowerUp>();

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
