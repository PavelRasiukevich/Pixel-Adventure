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

        public int Score { get => score; set => score = value; }
        public int Id { get => id; set => id = value; }
        public bool IsLoadAvaliable { get => isLoadAvaliable; set => isLoadAvaliable = value; }
        public CameraBoundValues CameraBoundValues { get => cameraBoundValues; set => cameraBoundValues = value; }

    }

}
