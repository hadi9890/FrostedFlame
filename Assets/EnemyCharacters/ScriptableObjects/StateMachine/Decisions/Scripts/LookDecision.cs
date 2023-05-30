using EnemyCharacters.Scripts;
using UnityEngine;

namespace EnemyCharacters.ScriptableObjects.StateMachine.Decisions.Scripts
{
    [CreateAssetMenu(menuName ="AI/Decisions/Look")]

    public class LookDecision : Decision
    {
        public override bool decide(StateController controller)
        {
            return look(controller);
        }

        private bool look(StateController controller)
        {
            FieldOfView fov = controller.GetComponent<FieldOfView>();

            if (!fov)
            {
                return false;
            }
            if (fov.visiblePlayer)
            {
                controller.target = fov.visiblePlayer;
                return true;
            }
            return false;
        }
    }
}
