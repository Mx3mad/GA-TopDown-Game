using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITransition : MonoBehaviour
{
    [SerializeField] List<AIDecision> decisions = new List<AIDecision>();
    [SerializeField] AIState newState = null;
    [SerializeField] bool applyOnZeroDecision = false;

    public bool TryTransition(BrainController owner)
    {
        if (decisions.Count == 0)
        {
            if (applyOnZeroDecision)
            {
                owner.TransitionToState(newState);
                return true;
            }
            else return false;
        }

        foreach (AIDecision d in decisions)
        {
            if (d.IsTrue(owner) == false)
                return d.IsTrue(owner);
        }

        owner.TransitionToState(newState);
        return true;
    }
}
