using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    [Serializable]
    public class AbilitySlotData
    {
        [SerializeField] List<bool> listOfValues;
        [SerializeField] List<Sprite> listOfSprites;
        [SerializeField] List<string> listOfNames;

        public List<bool> ListOfValues { get => listOfValues; }
        public List<Sprite> ListOfSprites { get => listOfSprites; }
        public List<string> ListOfNames { get => listOfNames; }

        public AbilitySlotData()
        {
            listOfValues = new List<bool>();
            listOfSprites = new List<Sprite>();
            listOfNames = new List<string>();
        }

        /// <summary>
        /// Initializes slots with default values
        /// </summary>
        public void InitSlotValues()
        {
            for (int i = 0; i < 6; i++)
            {
                listOfValues.Add(true);
                listOfSprites.Add(null);
                listOfNames.Add(string.Empty);
            }
        }
    }
}
