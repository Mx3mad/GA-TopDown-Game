using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AID_DistanceFromPlayer : AIDecision
{
    GameObject player = null;
    [SerializeField] float minDistance = 0.5f;
    [SerializeField] Color gizmoColor = Color.green;

    enum Distance { LessOrEqual, More }

    [SerializeField] Distance distance = Distance.LessOrEqual;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override bool IsTrue(BrainController owner)
    {
        if (player == null) return false;
        float dist = Vector2.Distance(owner.transform.position, player.transform.position);

        if (distance == Distance.LessOrEqual)
            return dist <= minDistance;
        
        return dist > minDistance;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, minDistance);
    }
}
