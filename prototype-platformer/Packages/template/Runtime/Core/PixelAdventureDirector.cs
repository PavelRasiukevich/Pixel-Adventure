using UnityEngine;

namespace PixelAdventure
{
    public abstract class PixelAdventureDirector : MonoBehaviour
    {
        protected virtual void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
