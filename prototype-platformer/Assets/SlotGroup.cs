using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class SlotGroup : MonoBehaviour
    {
        [SerializeField] List<Slot> listOfSlots;

        public void GetSlots()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                listOfSlots.Add(transform.GetChild(i).GetComponent<Slot>());
            }
        }

        public void SetSlotOccupation()
        {
            for (int i = 0; i < listOfSlots.Count; i++)
            {
                listOfSlots[i].IsEmpty = GameInfo.Instance.SlotValues[i];
                listOfSlots[i].SlotSprite = GameInfo.Instance.ListOfSprites[i];
                listOfSlots[i].Index = i;
            }
        }

        public Slot FindEmptySlot()
        {
            for (int i = 0; i < listOfSlots.Count; i++)
            {
                if (listOfSlots[i].IsEmpty)
                    return listOfSlots[i];
            }

            return null;
        }
    }
}
