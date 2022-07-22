using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIA_MoveToPlayer : AIAction
{
    public override void Act(BrainController owner)
    {
        EnemyBodyController body = owner.GetComponent<EnemyBodyController>();
        body.MoveToPlayer();
    }
}
