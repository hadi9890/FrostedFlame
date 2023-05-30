
using UnityEngine;
using UnityEngine.AI;

namespace EnemyCharacters.Scripts
{
    public enum currentState { Patrol, Inspect, Chase }
    public class Enemy : MonoBehaviour
    {
        public EnemyAnim animate;
        private static NavMeshAgent agent;
        public currentState currState;

        private void Awake()
        {
            animate = GetComponent<EnemyAnim>();
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (Mathf.Abs(agent.velocity.x) > 0.2f || Mathf.Abs(agent.velocity.z) > 0.2f)   // Checking the speed of the enemy agent
            {
                switch (currState)
                {
                    case currentState.Chase:
                        animate.Run(true);
                        break;
                    case currentState.Patrol:
                        animate.Walk(true);
                        break;
                    case currentState.Inspect:
                        animate.Search(true);
                        break;
                }
            }
            else
            {
                animate.Search(true);
            }
        }

    }
}