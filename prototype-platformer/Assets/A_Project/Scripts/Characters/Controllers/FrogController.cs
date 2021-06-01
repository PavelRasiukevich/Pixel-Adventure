using PixelAdventure.Interfaces;
using System;
using System.Collections;
using UnityEngine;

namespace PixelAdventure
{
    public class FrogController : BaseController
    {

        [SerializeField] bool canPick;
        [SerializeField] Item item;
        [SerializeField] Slot slot;

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
            inventory.NotifyPlayerAboutEquip = EquipHandler;
            inventory.NotifyPlayerAboutUnequip = UnequipHadler;
        }

        private void UnequipHadler(Item _item)
        {
            ItemUnEquiped.Invoke(_item);
        }

        private void EquipHandler(Item _item)
        {
            ItemEquiped.Invoke(_item);
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
            var _enemy = collision.gameObject.GetComponent<IDamaging>();

            if (_trampoline)
                OnNextStateRequest(CharacterState.TrampolineJump);
            else if (_enemy != null)
            {
                LifeLost.Invoke();
                OnNextStateRequest(CharacterState.Die);
            }
        }

        private new void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);

            if (collision.GetComponent<IPowerUp>() != null)
            {
                var _power = collision.GetComponent<IPowerUp>();

                _power.AddBonusValue();
                GetRewardPoints.Invoke();
                PowerUpConsumed.Invoke(_power.GetName);

            }
            else if (collision.GetComponent<CameraBoundSwitcher>() != null)
            {
                var _col = collision.GetComponent<CameraBoundSwitcher>().Values;
                GameInfo.Instance.KeepCameraBounds(_col);
                ChangeCameraBound.Invoke(_col);
            }
            else if (collision.GetComponent<Item>() != null)
            {
                item = collision.GetComponent<Item>();
                item.CanBePicked = true;
                item.ShowDisplay(item.CanBePicked);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.GetComponent<Item>() != null)
            {
                item = collision.GetComponent<Item>();
                item.CanBePicked = false;
                item.ShowDisplay(item.CanBePicked);
            }
        }

        private void Update()
        {
            if (Input.GetAxis("Use") > 0 && item != null && item.CanBePicked)
            {
                PickUpItem();
            }
        }

        private void PickUpItem()
        {
            slot = inventory.SlotGroup.FindEmptySlot();

            if (slot)
            {
                item.Off();
                slot.InputItemInSlot(item);
                GameInfo.Instance.SetItemState(item.Index, ItemState.Picked);
                GameInfo.Instance.SlotValues[slot.Index] = slot.IsEmptySlot;
                GameInfo.Instance.ListOfSprites[slot.Index] = item.ItemSprite;

            }
            else
            {
                throw new Exception("No empty slots in inventory");
            }
        }
    }
}
