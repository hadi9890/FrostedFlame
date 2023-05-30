using EnemyCharacters.Scripts;
using UnityEngine;

namespace EnemyCharacters.ScriptableObjects.StateMachine.Actions.Scripts
{
    [CreateAssetMenu(menuName = "AI/Actions/Patrol")]
    public class PatrolAction : Action
    {
        public override void Act(StateController controller)
        {
            // Debug.Log("Patrolling");
            patrol(controller);
        }

        private void patrol(StateController controller)
        {
            //Setting the enemy to patrol with a walk speed from the scriptable object of EnemyStats
            Enemy enemy = controller.GetComponent<Enemy>();
            enemy.currState = currentState.Patrol;
            controller.agent.speed = controller.enemyStats.walkSpeed;

            //Setting the new waypoint for the agent while patrolling
            controller.agent.destination = controller.waypoints[controller.nextWaypoint].position;
        
            // controller.agent.Resume();
            controller.agent.isStopped = false;

            if(controller.agent.remainingDistance <= controller.agent.stoppingDistance && !controller.agent.pathPending)
            {
                // Completing the patrolling circle
                // Whenever the enemy gets to the last waypoint, the starting waypoint will become the next one,
                // and the loop will continue looping
                controller.nextWaypoint = (controller.nextWaypoint + 1) % controller.waypoints.Count;
            }
        }
    }
}
