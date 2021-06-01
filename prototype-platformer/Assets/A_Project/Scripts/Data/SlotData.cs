using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    [Serializable]
    public class SlotData
    {
        [SerializeField] List<bool> listOfFullness;
        [SerializeField] List<Sprite> listOfSprites;
        [SerializeField] List<ItemModel> listOfItems;


        public SlotData()
        {
            listOfFullness = new List<bool>();
            listOfSprites = new List<Sprite>();
            listOfItems = new List<ItemModel>();
        }

        public List<bool> ListOfFullness { get => listOfFullness; }
        public List<Sprite> ListOfSprites { get => listOfSprites; }
        public List<ItemModel> ListOfItems { get => listOfItems; }

        /// <summary>
        /// Initializes slots with default values
        /// </summary>
        public void InitSlotValues()
        {
            for (int i = 0; i < 16; i++)
            {
                listOfFullness.Add(true);
                listOfSprites.Add(null);
                listOfItems.Add(null);
            }
        }

       
    }
}
