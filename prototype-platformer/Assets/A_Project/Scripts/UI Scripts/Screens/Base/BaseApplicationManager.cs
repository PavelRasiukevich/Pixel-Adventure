using UnityEngine;

namespace PixelAdventure
{
    public abstract class BaseApplicationManager : MonoBehaviour
    {
        protected virtual void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
