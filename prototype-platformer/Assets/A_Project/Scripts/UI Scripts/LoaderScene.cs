using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelAdventure
{
    public class LoaderScene : MonoBehaviour
    {
        private void Awake()
        {
            AudioManager.Instance.SetupVolume();
            SceneManager.LoadScene(SceneID.MAIN_MENU_ID);
        }
    }
}
