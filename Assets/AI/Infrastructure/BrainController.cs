using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainController : MonoBehaviour
{
    [SerializeField] AIState currentState = null;
    //[SerializeField] AIState lastState = null;

    private void Update()
    {
        if (currentState != null)
            currentState.StartState(this);
    }

    public void TransitionToState(AIState newState)
    {
        if (newState == currentState) return;
        else currentState = newState;
    }
}
