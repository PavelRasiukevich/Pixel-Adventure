using UnityEngine;

namespace PixelAdventure
{
    public class TransitionManager : BaseManager<TransitionManager>
    {
        [SerializeField] TransitionScreen fadeScreen;

        public void ApplyTransition(string _id)
        {
            fadeScreen.PlayAnimation(_id);
        }
    }
}
