using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AID_IsInStartPosition : AIDecision
{
    enum GuardingPosition { On, Out }

    [SerializeField] GuardingPosition pos = GuardingPosition.Out;

    public override bool IsTrue(BrainController owner)
    {
        EnemyBodyController body = owner.GetComponent<EnemyBodyController>();

        if (pos == GuardingPosition.Out)
            return body.transform.position != body.initialPos;

        return body.transform.position == body.initialPos;
    }
}
