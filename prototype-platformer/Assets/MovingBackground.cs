using UnityEngine;

namespace PixelAdventure
{
    public class MovingBackground : MonoBehaviour
    {
        [SerializeField] float scrollSpeed;
        [SerializeField] float coof;
        [SerializeField] Options options;

        Vector3 startPosition;
        float boundY;
        SpriteRenderer spriteRend;
        BoxCollider2D boxC2D;

        private void Awake()
        {
            if (options.Equals(Options.Renderer))
            {
                spriteRend = GetComponent<SpriteRenderer>();
                boundY = spriteRend.bounds.extents.y;
            }
            else if (options.Equals(Options.Collider))
            {
                boxC2D = GetComponent<BoxCollider2D>();
                boundY = boxC2D.bounds.extents.y;
            }

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

    public enum Options
    {
        Renderer,
        Collider
    }
}
