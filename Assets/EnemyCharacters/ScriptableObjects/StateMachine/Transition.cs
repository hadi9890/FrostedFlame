
using EnemyCharacters.ScriptableObjects.StateMachine.Decisions.Scripts;
using EnemyCharacters.ScriptableObjects.StateMachine.States.Scripts;

namespace EnemyCharacters.ScriptableObjects.StateMachine
{
    [System.Serializable]
    public class Transition
    {
        public Decision decision;
        public State trueState;
        public State falseState;
    }
}
