
using EnemyCharacters.Scripts;
using UnityEngine;

namespace EnemyCharacters.ScriptableObjects.StateMachine.Actions.Scripts
{
    [CreateAssetMenu(menuName = "AI/Actions/Chase")]
    
    public class ChaseAction : Action
    {
        public override void Act(StateController controller)
        {
            chase(controller);
        }

        private static void chase(StateController controller)
        {
            //Setting the enemy to chase with an attack speed from the scriptable object of EnemyStats
            Enemy enemy = controller.GetComponent<Enemy>();
            enemy.currState = currentState.Chase;
            controller.agent.speed = controller.enemyStats.runSpeed;

            FieldOfView fov = controller.GetComponent<FieldOfView>();

            if (!fov)
            {
                return;
            }
            if (fov.visiblePlayer)
            {
                controller.agent.destination = controller.target.position;
                controller.lastKnownTargetPosition = controller.agent.destination;
                controller.agent.isStopped = false;
            }
            else
            {
                controller.agent.destination = controller.lastKnownTargetPosition;
                controller.agent.isStopped = false;
            }
        }
    }
}
