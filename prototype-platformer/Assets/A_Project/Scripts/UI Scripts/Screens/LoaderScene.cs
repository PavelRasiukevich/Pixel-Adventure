using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelAdventure
{
    public class LoaderScene : MonoBehaviour
    {
        [SerializeField] Canvas canv;

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
                canv.sortingOrder = 555;
                TransitionManager.Instance.ApplyTransition(SceneID.MAIN_MENU_ID);
            }
        }
    }
}
