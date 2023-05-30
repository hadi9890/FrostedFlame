using System.Collections.Generic;
using EnemyCharacters.ScriptableObjects.Scripts;
using EnemyCharacters.ScriptableObjects.StateMachine.States.Scripts;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyCharacters.ScriptableObjects.StateMachine
{
    public class StateController : MonoBehaviour
    {
        public EnemyStats enemyStats;
        public State currState;
        public State remainState;
        public Transform eyes;

        [HideInInspector] public NavMeshAgent agent;
        [HideInInspector] public Shoot shoot;
        [HideInInspector] public List<Transform> waypoints;
        [HideInInspector] public int nextWaypoint;
        [HideInInspector] public Transform target;
        [HideInInspector] public Vector3 lastKnownTargetPosition;
        [HideInInspector] public bool stateBoolVar;
        [HideInInspector] public float stateTimeElapsed;
        private bool isActive;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            shoot = GetComponent<Shoot>();
        }

        public void initializeAI(bool activate, List<Transform> waypointsList)
        {
            waypoints = waypointsList;
            isActive = activate;
            agent.enabled = isActive;
        }

        private void Update()
        {
            if (!isActive)
            {
                return;
            }
            currState.updateState(this);
        }

        public void transitionToState(State nextState)
        {
            if (nextState != remainState)
            {
                currState = nextState;
                onExitState();
            }
        }

        public bool hasTimeElapsed(float dur)
        {
            stateTimeElapsed += Time.deltaTime;
            if (stateTimeElapsed >= dur)
            {
                stateTimeElapsed = 0;
                return true;
            }
            else
            {
                return false;
            }
        }
    
        // Resetting timer every time the enemy exits a state
        private void onExitState()
        {
            stateBoolVar = false;
            stateTimeElapsed = 0;
        }

        private void OnDrawGizmos()
        {
            if (currState != null)
            {
                Gizmos.color = currState.gizmoColor;
                Gizmos.DrawWireSphere(eyes.position, 1.5f);
            }
        }
    }
}
