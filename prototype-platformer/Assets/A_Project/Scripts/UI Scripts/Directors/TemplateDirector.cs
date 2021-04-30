using UnityEngine.SceneManagement;
using UnityEngine;

namespace PixelAdventure
{
    public class TemplateDirector : PixelAdventureDirector
    {
        protected override void Awake()
        {
            base.Awake();
            SceneManager.LoadScene(SceneID.MAIN_MENU_ID);
        }

        private void Start()
        {
            GameInfo.Instance.Setup();
        }
    }
}
      