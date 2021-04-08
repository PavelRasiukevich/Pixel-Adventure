using PixelAdventure.Interfaces;

namespace PixelAdventure
{
    public class FrogController : BaseController, IControllable
    {
        private new void Awake()
        {
            base.Awake();

            transform.position = spawn.position;
        }
    }
}
