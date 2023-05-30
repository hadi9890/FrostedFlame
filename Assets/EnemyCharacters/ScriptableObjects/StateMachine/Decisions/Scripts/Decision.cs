using UnityEngine;

namespace EnemyCharacters.ScriptableObjects.StateMachine.Decisions.Scripts
{
    public abstract class Decision : ScriptableObject
    {
        public abstract bool decide(StateController controller);
    }
}
