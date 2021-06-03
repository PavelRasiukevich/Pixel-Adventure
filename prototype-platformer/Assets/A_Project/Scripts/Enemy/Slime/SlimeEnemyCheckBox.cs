using System;
using UnityEngine;

namespace PixelAdventure
{
    public class SlimeEnemyCheckBox : MonoBehaviour
    {
        public Action WallReached;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            WallReached.Invoke();
        }
    }
}
