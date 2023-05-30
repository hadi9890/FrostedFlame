
using System.Collections;
using System.Collections.Generic;
using EnemyCharacters.ScriptableObjects.StateMachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Transform> waypoints;
    private StateController[] controllers;

    private void Start()
    {
        controllers = FindObjectsOfType<StateController>();

        foreach (var controller in controllers)
        {
            controller.initializeAI(true, waypoints);
        }
    }
}
