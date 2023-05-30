using UnityEngine;

namespace EnemyCharacters.ScriptableObjects.StateMachine.Decisions.Scripts
{
    [CreateAssetMenu(menuName = "AI/Decisions/Inspect")]

    public class InspectDecision : Decision
    {
        public override bool decide(StateController controller)
        {
            return playerInspect(controller);
        }


        //Enemy turns around to see where the player is when he is not visible
        private bool playerInspect(StateController controller)
        {
            controller.transform.Rotate(0, controller.enemyStats.searchTurnSpeed * Time.deltaTime, 0);
            return controller.hasTimeElapsed(controller.enemyStats.searchTime);
        }
    }
}
