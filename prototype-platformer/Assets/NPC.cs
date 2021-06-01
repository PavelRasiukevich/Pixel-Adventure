using UnityEngine;

namespace PixelAdventure
{
    public class NPC : MonoBehaviour
    {
        [SerializeField] FraseSet_SO dialog;

        public FraseSet_SO Dialog { get => dialog;}

    }
}
