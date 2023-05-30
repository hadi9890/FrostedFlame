
using EnemyCharacters.Scripts;
using UnityEngine;

namespace EnemyCharacters.ScriptableObjects.StateMachine.Actions.Scripts
{
    [CreateAssetMenu(menuName = "AI/Actions/Attack")]

    public class AttackAction : Action
    {
        public override void Act(StateController controller)
        {
            Attack(controller);
        }

        private static void Attack(StateController controller)
        {
            FieldOfView fov = controller.GetComponent<FieldOfView>();

            if (!fov)
            {
                return;
            }

            if (!controller.stateBoolVar)
            {
                controller.stateTimeElapsed = controller.enemyStats.attackRate;
                controller.stateBoolVar = true;
            }

            if (fov.visiblePlayer)
            {
                if (controller.hasTimeElapsed(controller.enemyStats.attackRate))
                {
                    controller.shoot.shootPlayer(controller.enemyStats.dmg);
                }
            }
        }
    }
}
