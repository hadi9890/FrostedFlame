
using UnityEngine;

namespace EnemyCharacters.Scripts
{
    public class EnemyAnim : MonoBehaviour
    {
        public Animator anim;
        private static readonly int IsWalking = Animator.StringToHash("isWalking");
        private static readonly int IsRunning = Animator.StringToHash("isRunning");
        private static readonly int IsSearching = Animator.StringToHash("isSearching");
        private static readonly int Speed = Animator.StringToHash("Speed");

        private void Awake()
        {
            anim = GetComponentInChildren<Animator>();
        }

        public void Walk(bool isWalking)
        {
            anim.SetBool(IsWalking, isWalking);
            anim.SetBool(IsRunning, false);
            anim.SetBool(IsSearching, false);
            anim.SetFloat(Speed, 0.5f, 0.2f, Time.deltaTime);
        }

        public void Run(bool isRunning)
        {
            anim.SetBool(IsRunning, isRunning);
            anim.SetBool(IsWalking, false);
            anim.SetBool(IsSearching, false);
            anim.SetFloat(Speed, 1.0f, 0.2f, Time.deltaTime);
        }

        public void Search(bool isSearching)
        {
            anim.SetBool(IsRunning, false);
            anim.SetBool(IsWalking, false);
            anim.SetBool(IsSearching, isSearching);
            anim.SetFloat(Speed, 0.0f, 0.2f, Time.deltaTime);
        }

    }
}
