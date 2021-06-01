using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    [CreateAssetMenu(fileName = "Dialog", menuName = "Story/Dialog")]
    public class FraseSet_SO : ScriptableObject
    {
        [TextArea(5,25)]
        [SerializeField] List<string> frases;

        public List<string> Frases { get => frases; }
    }
}
