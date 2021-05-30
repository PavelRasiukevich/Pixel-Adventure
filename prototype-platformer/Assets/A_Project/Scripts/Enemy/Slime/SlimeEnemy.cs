using UnityEngine;

namespace PixelAdventure
{
    public class SlimeEnemy : MonoBehaviour, IDamaging
    {
        [SerializeField] float moveSpeed;
        [SerializeField] SlimeEnemyCheckBox chckbox;

        Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            chckbox.WallReached = ActionHandler;
        }

        private void ActionHandler()
        {
            moveSpeed = -moveSpeed;
        }

        private void FixedUpdate()
        {
            var _velocity = rb.velocity;
            _velocity.x = moveSpeed;
            rb.velocity = _velocity;

            if (rb.velocity.x < 0)
                transform.localScale = new Vector2(1, 1);
            else if (rb.velocity.x > 0)
                transform.localScale = new Vector2(-1, 1);
        }
    }
}
