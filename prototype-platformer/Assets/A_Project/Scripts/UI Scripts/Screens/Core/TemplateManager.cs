using UnityEngine.SceneManagement;
using UnityEngine;

namespace PixelAdventure
{
    public class TemplateManager : PixelAdventureDirector
    {
        protected override void Awake()
        {
            base.Awake();
            SceneManager.LoadScene(SceneID.MAIN_MENU_ID);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                PlayerPrefs.DeleteAll();
            }
        }
    }
}
