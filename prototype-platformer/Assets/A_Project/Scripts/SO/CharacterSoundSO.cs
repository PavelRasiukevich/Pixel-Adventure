using UnityEngine;

namespace PixelAdventure
{
    public class CharacterSoundSO : ScriptableObject
    {
        [SerializeField] protected AudioClip jumpSound;
        [SerializeField] protected AudioClip doubleJumpSound;
        [SerializeField] protected AudioClip groundedSound;
        [SerializeField] protected AudioClip deathSound;


        public AudioClip JumpSound { get => jumpSound; }
        public AudioClip DoubleJumpSound { get => doubleJumpSound; }
        public AudioClip GroundedSound { get => groundedSound; }
        public AudioClip DeathSound { get => deathSound; }
    }
}
