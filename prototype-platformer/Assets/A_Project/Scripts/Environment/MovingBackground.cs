using UnityEngine;
using UnityEngine.UI;

namespace PixelAdventure
{
    public class MovingBackground : MonoBehaviour
    {
        [SerializeField] float scrollSpeed;
        [SerializeField] float valueBound;

        RawImage rawImg;
        Rect uvRect;
        private void Awake()
        {
            rawImg = GetComponent<RawImage>();
        }

        private void Update()
        {
            uvRect = rawImg.uvRect;
            uvRect.y += scrollSpeed * Time.deltaTime;
            uvRect.y = Mathf.Repeat(uvRect.y, valueBound);
            rawImg.uvRect = uvRect;
        }
    }
}
