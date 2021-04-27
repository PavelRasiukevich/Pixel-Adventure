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

        private void Start()
        {
            GameInfo.Instance.LifeAmount = 3;
            GameInfo.Instance.Setup();
            
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
