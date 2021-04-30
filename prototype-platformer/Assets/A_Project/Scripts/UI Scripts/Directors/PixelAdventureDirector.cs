using UnityEngine.SceneManagement;
using UnityEngine;

namespace PixelAdventure
{
    public class PixelAdventureDirector : ApplicationDirector
    {
        private void Start()
        {
            GameInfo.Instance.Setup();
            AudioManager.Instance.SetupVolume();
            SceneManager.LoadScene(SceneID.MAIN_MENU_ID);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                AppPrefs.DeleteAll();
            }
        }
    }
}
