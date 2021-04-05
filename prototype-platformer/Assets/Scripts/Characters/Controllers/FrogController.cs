namespace PixelAdventure
{
    public class FrogController : BaseController
    {
        private new void Awake()
        {
            base.Awake();
            transform.position = base.spawn.position;
            OnChangePosition.Invoke(transform);
        }
    }
}
