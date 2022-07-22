using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIA_MoveToStartingPoint : AIAction
{
    public override void Act(BrainController owner)
    {
        EnemyBodyController body = owner.GetComponent<EnemyBodyController>();
        body.MoveToTarget(body.initialPos);
    }
}
