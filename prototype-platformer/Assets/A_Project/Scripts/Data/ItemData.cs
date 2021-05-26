using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    [Serializable]
    public class ItemData
    {
        [SerializeField] List<ItemState> listOfItemStates;

        public List<ItemState> ListOfItemStates { get => listOfItemStates; }

        public ItemData()
        {
            listOfItemStates = new List<ItemState>();
        }
    }
}
