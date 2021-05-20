using UnityEngine;

namespace PixelAdventure
{
    public class MovingBackground : MonoBehaviour
    {
        [SerializeField] float scrollSpeed;

        Vector3 startPosition;
        float boundY;
        SpriteRenderer spriteRend;

        private void Awake()
        {
            spriteRend = GetComponent<SpriteRenderer>();
            boundY = spriteRend.bounds.size.y;
            startPosition = transform.position;
        }

        private void Update()
        {
            transform.position += Vector3.down * scrollSpeed * Time.deltaTime;

            if (Mathf.Abs(GetDifference()) > boundY)
                transform.position = startPosition;
        }

        private float GetDifference()
        {
            return transform.position.y - startPosition.y;
        }
    }
}
