using UnityEngine.SceneManagement;

namespace PixelAdventure
{
    public class TemplateManager : BaseApplicationManager
    {
        protected override void Awake()
        {
            base.Awake();
            SceneManager.LoadScene(SceneID.MAIN_MENU_ID);
        }
    }
}
