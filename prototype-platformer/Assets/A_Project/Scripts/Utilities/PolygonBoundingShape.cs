using UnityEngine;

namespace PixelAdventure
{
    public class PolygonBoundingShape : MonoBehaviour
    {
        PolygonCollider2D col;

        private void Awake()
        {
            col = GetComponent<PolygonCollider2D>();
        }

        public PolygonCollider2D GetBoundingShape()
        {
            return col;
        }
    }
}
