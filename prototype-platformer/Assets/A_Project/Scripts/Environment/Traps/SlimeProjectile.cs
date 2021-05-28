using UnityEngine;

namespace PixelAdventure
{
    public class SlimeProjectile : MonoBehaviour, IDamaging
    {
        [SerializeField] float deathTime;

        Rigidbody2D slimeRb;

        private void Awake()
        {
            slimeRb = GetComponent<Rigidbody2D>();
            Destroy(gameObject, deathTime);
        }

        public void SetPosition(Vector2 _pos)
        {
            transform.position = _pos;
            transform.rotation = Quaternion.identity;
        }

        public void AddForce(float _value)
        {
            slimeRb.AddForce(Vector2.up * _value, ForceMode2D.Impulse);
        }
       
    }
}
