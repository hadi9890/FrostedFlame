using UnityEngine;

namespace EnemyCharacters.ScriptableObjects.StateMachine.Actions.Scripts
{
    public abstract class Action : ScriptableObject
    {
        public abstract void Act(StateController controller);
    }
}
