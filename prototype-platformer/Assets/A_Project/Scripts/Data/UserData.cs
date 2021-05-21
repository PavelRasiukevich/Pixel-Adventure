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
        [SerializeField] GameTime gameTime;

        public int Score { get => score; set => score = value; }
        public int Id { get => id; set => id = value; }
        public bool IsLoadAvaliable { get => isLoadAvaliable; set => isLoadAvaliable = value; }
        public GameTime GameTime { get => gameTime; set => gameTime = value; }

        public UserData()
        {
            GameTime = new GameTime();
        }

    }

    [Serializable]
    public class GameTime
    {
        [SerializeField] string minutes;
        [SerializeField] string seconds;

        public string Minutes { get => minutes; set => minutes = value; }
        public string Seconds { get => seconds; set => seconds = value; }
    }
}
