using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    [Serializable]
    public class SlotData
    {
        [SerializeField] List<bool> listOfValues;
        [SerializeField] List<Sprite> listOfSprites;

        public SlotData()
        {
            listOfValues = new List<bool>();
            listOfSprites = new List<Sprite>();
        }

        public List<bool> ListOfValues { get => listOfValues;}
        public List<Sprite> ListOfSprites { get => listOfSprites; }

        /// <summary>
        /// Initializes slots with default values
        /// </summary>
        public void InitSlotValues()
        {
            for (int i = 0; i < 8; i++)
            {
                listOfValues.Add(true);
                listOfSprites.Add(null);
            }
        }
    }
}
