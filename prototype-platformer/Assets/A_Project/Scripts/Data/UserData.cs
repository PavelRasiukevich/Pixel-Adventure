using System;
using UnityEngine;

namespace PixelAdventure
{
    [Serializable]
    public class UserData
    {
        [SerializeField] int score;
        [SerializeField] int id;
        [SerializeField] bool isLoadAvaliable;
        [SerializeField] CameraBoundValues cameraBoundValues;
        [SerializeField] CameraBoundValues keepedValues;

        public int Score { get => score; set => score = value; }
        public int Id { get => id; set => id = value; }
        public bool IsLoadAvaliable { get => isLoadAvaliable; set => isLoadAvaliable = value; }
        public CameraBoundValues CameraBoundValues { get => cameraBoundValues; private set => cameraBoundValues = value; }
        public CameraBoundValues KeepedValues { get => keepedValues; set => keepedValues = value; }

         public void SetBoundsValues()
        {
            cameraBoundValues = keepedValues;
        }
    }

}
