using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState : MonoBehaviour
{
    [SerializeField] List<AIAction> actions = new List<AIAction>();
    [SerializeField] List<AITransition> transitions = new List<AITransition>();
    string stateName;

    public void StartState(BrainController owner)
    {
        foreach (AIAction a in actions)
        {
            a.Act(owner);
        }
        foreach (AITransition t in transitions)
        {
            if (t.TryTransition(owner)) return;
        }
    }

    public void OnUpdate()
    {

    }

    public void OnExit()
    {

    }
}
