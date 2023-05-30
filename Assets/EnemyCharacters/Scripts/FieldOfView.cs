
using UnityEngine;

namespace EnemyCharacters.Scripts
{
    public class FieldOfView : MonoBehaviour
    {
        public float viewRadius;
        public float viewAngle;
        public LayerMask player;
        public LayerMask obstacles;
        public Transform visiblePlayer;

        private void FixedUpdate()
        {
            findPlayer();
        }

        private void findPlayer()
        {
            visiblePlayer = null;
            Collider[] playerInRadius = Physics.OverlapSphere(transform.position, viewRadius, player);

            foreach (Collider selectedPlayer in playerInRadius)
            {
                Transform player = selectedPlayer.transform;
                Vector3 dirToPlayer = (player.position - transform.position).normalized;

                if (Vector3.Angle(transform.forward, dirToPlayer) < viewAngle / 2)
                {
                    float distanceToPlayer = Vector3.Distance(transform.position, player.position);

                    if (!Physics.Raycast(transform.position, dirToPlayer, distanceToPlayer, obstacles))
                    {
                        visiblePlayer = player;
                    }
                }
            }
        }
        
        public Vector3 directionFromAngle(float angleInDegrees, bool angleIsGlobal)
        {
            if (!angleIsGlobal)
            {
                angleInDegrees += transform.eulerAngles.y;
            }
            return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0f, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
        }

    }
}
