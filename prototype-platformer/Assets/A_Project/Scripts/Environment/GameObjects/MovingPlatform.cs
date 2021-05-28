using UnityEngine;

namespace PixelAdventure
{
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] MovingPlatformSideCollider detector;

        Vector2 currentPos;
        int direction;

        private void Awake()
        {
            direction = 1;
        }

        private void OnEnable()
        {
            detector.ReachWall = OnWallReachedHandler;
        }

        private void OnWallReachedHandler()
        {
            var _localSacle = transform.localScale;
            _localSacle.x = -_localSacle.x;
            transform.localScale = _localSacle;

            direction = -direction;
        }

        private void Update()
        {
            currentPos = transform.position;
            currentPos.x += speed * Time.deltaTime * direction;
            transform.position = currentPos;
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            var _player = collision.gameObject.GetComponentInParent<BaseController>();

            if (_player)
            {
                var _pos = _player.transform.position;
                _pos.x += speed * Time.deltaTime * direction;
                _player.transform.position = _pos;
            }
        }
    }
}
