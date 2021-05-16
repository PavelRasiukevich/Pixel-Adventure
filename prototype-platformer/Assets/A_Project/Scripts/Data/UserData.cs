using System;
using UnityEngine;

namespace PixelAdventure
{
    [Serializable]
    public class UserData
    {
        [SerializeField] int score;
        [SerializeField] int id;

        public int Score { get => score; set => score = value; }
        public int Id { get => id; set => id = value; }
    }
}
