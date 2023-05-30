using EnemyCharacters.ScriptableObjects.StateMachine.Actions.Scripts;
using UnityEngine;

namespace EnemyCharacters.ScriptableObjects.StateMachine.States.Scripts
{
    [CreateAssetMenu(menuName = "AI/State")]

    public class State : ScriptableObject
    {
        public Action[] actions;
        public Transition[] transitions;
        public Color gizmoColor = Color.magenta;

        public void updateState(StateController controller)
        {
            executeActions(controller);
            checkForTransitions(controller);
        }

        private void executeActions(StateController controller)
        {
            foreach (var action in actions)
            {
                action.Act(controller);
            }
        }

        private void checkForTransitions(StateController controller)
        {
            foreach (var transition in transitions)
            {
                bool decision = transition.decision.decide(controller);

                if (decision)
                {
                    controller.transitionToState(transition.trueState);
                }
                else
                {
                    controller.transitionToState(transition.falseState);
                }
            }
        }
    }
}
