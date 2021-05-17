using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public static class SpriteFlipper
    {
        public static void FlipSprite(Rigidbody2D _rigidBody,SpriteRenderer _renderer)
        {
            if (_rigidBody.velocity.x > 0)
                _renderer.gameObject.transform.localScale = new Vector2(1, 1);
            else if (_rigidBody.velocity.x < 0)
                _renderer.gameObject.transform.localScale = new Vector2(-1, 1);
        }
    }
}
