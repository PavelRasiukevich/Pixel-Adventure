using UnityEngine;

namespace PixelAdventure
{
    public class MovingBackground : MonoBehaviour
    {
        [SerializeField] float scrollSpeed;
        [SerializeField] float coof;
        Vector3 startPosition;
        float boundY;
        SpriteRenderer spriteRend;

        private void Awake()
        {
            spriteRend = GetComponent<SpriteRenderer>();

            boundY = spriteRend.bounds.extents.y;
            startPosition = transform.position;
        }

        private void Update()
        {
            transform.position += Vector3.down * scrollSpeed * Time.deltaTime;

            if (Mathf.Abs(GetDifference()) > boundY / coof)
                transform.position = startPosition;
        }

        private float GetDifference()
        {
            return (transform.position.y - startPosition.y);
        }
    }
}
