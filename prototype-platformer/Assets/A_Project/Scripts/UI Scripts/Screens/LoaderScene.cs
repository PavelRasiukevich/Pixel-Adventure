using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelAdventure
{
    public class LoaderScene : MonoBehaviour
    {
        private void Awake()
        {
            //TODO localization setup

            AudioManager.Instance.SetupVolume();
            SceneManager.LoadScene(SceneID.MAIN_MENU_ID);
        }
    }
}
