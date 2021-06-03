using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelAdventure
{
    public class LoaderScene : MonoBehaviour
    {
        [SerializeField] Canvas canv;
        bool isKeyPressed;
        private void Awake()
        {
            canv = GetComponentInChildren<Canvas>();
            canv.sortingOrder = 777;
            AudioManager.Instance.SetupVolume();
        }

        void Update()
        {
            if (Input.anyKeyDown)
            {
                if (!isKeyPressed)
                {
                    canv.sortingOrder = 555;
                    TransitionManager.Instance.ApplyTransition(SceneID.MAIN_MENU_ID);
                    isKeyPressed = true;
                }
            }
        }
    }
}
