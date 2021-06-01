using System;
using System.Collections;
using UnityEngine;

namespace PixelAdventure
{
    public class FrogController : BaseController
    {

        [SerializeField] bool canPick;
        [SerializeField] bool canSpeakWithNPC;
        [SerializeField] Item item;
        [SerializeField] Slot slot;
      
        FrogMove frogMove;
        FrogFastFall frogFastFall;
        FrogDoubleJump frogDoubleJump;
        InDialogState inDialog;

        private new void Awake()
        {
            base.Awake();
            transform.position = GameInfo.Instance.GetPositionBySavePointId();
            frogMove = listOfStates.Find(_s => _s.State.Equals(CharacterState.Move)) as FrogMove;
            frogFastFall = listOfStates.Find(_s => _s.State.Equals(CharacterState.FastFall)) as FrogFastFall;
            frogDoubleJump = listOfStates.Find(_s => _s.State.Equals(CharacterState.DoubleJump)) as FrogDoubleJump;
            inDialog = listOfStates.Find(_s => _s.State.Equals(CharacterState.Dialog)) as InDialogState;
        }

        private new void OnEnable()
        {
            base.OnEnable();
            inDialog.SkipFrase = OnSkipFraseHandler;
            frogMove.PlayerUsedDash = OnDashPlayerHandler;
            frogFastFall.FastFallUsed = OnFastFallPlayerHandler;
            frogDoubleJump.DoubleJumpUsed = OnDoubleJumpPlayerHandler;
            inventory.NotifyPlayerAboutEquip = EquipHandler;
            inventory.NotifyPlayerAboutUnequip = UnequipHadler;
        }


        private void OnSkipFraseHandler()
        {
            NextFrase.Invoke();
        }

        private void UnequipHadler(ItemModel _item)
        {
            ItemUnEquiped.Invoke(_item);
        }

        private void EquipHandler(ItemModel _item)
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

        private new void OnTriggerEnter2D(Collider2D trigger)
        {
            base.OnTriggerEnter2D(trigger);

            if (trigger.GetComponent<IPowerUp>() != null)
            {
                var _power = trigger.GetComponent<IPowerUp>();

                _power.AddBonusValue();
                GetRewardPoints.Invoke();
                PowerUpConsumed.Invoke(_power.GetName);

            }
            else if (trigger.GetComponent<CameraBoundSwitcher>() != null)
            {
                var _col = trigger.GetComponent<CameraBoundSwitcher>().Values;
                GameInfo.Instance.KeepCameraBounds(_col);
                ChangeCameraBound.Invoke(_col);
            }
            else if (trigger.GetComponent<Item>() != null)
            {
                item = trigger.GetComponent<Item>();
                item.ItemModel.canBePicked = true;
                item.ShowDisplay(item.ItemModel.canBePicked);
            }

            else if (trigger.GetComponent<NPC>() != null)
            {
                var _NPC = trigger.GetComponent<NPC>();
                Npc = _NPC;
                canSpeakWithNPC = true;
            }
        }

        private void OnTriggerExit2D(Collider2D trigger)
        {
            if (trigger.GetComponent<Item>() != null)
            {
                item = trigger.GetComponent<Item>();
                item.ItemModel.canBePicked = false;
                item.ShowDisplay(item.ItemModel.canBePicked);
            }
            else if (trigger.GetComponent<NPC>() != null)
            {
                var _NPC = trigger.GetComponent<NPC>();
                canSpeakWithNPC = false;
            }
        }

        private void Update()
        {
            if (Input.GetAxis("Use") > 0 && item != null && item.ItemModel.canBePicked)
            {
                PickUpItem();
            }

            if (canSpeakWithNPC)
            {
                if(Input.GetAxis("Use") > 0)
                {
                    OnNextStateRequest(CharacterState.Dialog);
                    BeginConversation.Invoke();
                }
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
                GameInfo.Instance.SlotFullness[slot.Index] = slot.IsEmptySlot;
                GameInfo.Instance.ListOfSprites[slot.Index] = item.ItemModel.itemSprite;
                GameInfo.Instance.ListOfItems[slot.Index] = item.ItemModel;
            }
            else
            {
                throw new Exception("No empty slots in inventory");
            }
        }
    }
}
