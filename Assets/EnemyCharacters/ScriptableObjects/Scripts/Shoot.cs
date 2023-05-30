
using UnityEngine;
using UnityEngine.AI;

namespace EnemyCharacters.ScriptableObjects.Scripts
{
    public class Shoot : MonoBehaviour
    {
        public NavMeshAgent agent;
        public Transform player;

        public void shootPlayer(int damage)
        {
            float distancetoPlayer = Vector3.Distance(transform.position, player.position);

            if (distancetoPlayer <= agent.stoppingDistance)
            {
                Health.Health.takeDamage(damage);
            }
        }
    }
}
