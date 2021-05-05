using UnityEngine.SceneManagement;
using UnityEngine;

namespace PixelAdventure
{
    public class PixelAdventureDirector : ApplicationDirector
    {
        private void Start()
        {
            SceneManager.LoadScene(SceneID.LOADER_ID);
        }

      
    }
}
