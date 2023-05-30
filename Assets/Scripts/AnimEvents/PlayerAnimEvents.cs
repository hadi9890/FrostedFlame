
using UnityEngine;

namespace AnimEvents
{
    public class PlayerAnimEvents : MonoBehaviour
    {

        [Tooltip("Audio clips of snow footstep sounds to randomize while walking")]
        [SerializeField] private AudioClip[] clips;
        public AudioSource audioSound;

        private void Awake()
        {
            audioSound = GetComponent<AudioSource>();
        }

        private AudioClip GetRandomClip()
        {
            return clips[UnityEngine.Random.Range(0, clips.Length)];
        }

        private void Step(float walkSpeed)
        {
            AudioClip clip = GetRandomClip();
            audioSound.volume = 0.32f;
            audioSound.PlayOneShot(clip);
        }

        private void DamageEnemy(int dmg)
        {
            
        }

    }
}
