using UnityEngine;

namespace PixelAdventure
{
    public abstract class ApplicationDirector : MonoBehaviour
    {
        protected virtual void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
