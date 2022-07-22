using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AID_IsPlayerHurt : AIDecision
{
    enum Player { Hit, NotHit }

    [SerializeField] Player player = Player.Hit;

    public override bool IsTrue(BrainController owner)
    {
        EnemyWeapon weapon = owner.GetComponentInChildren<EnemyWeapon>();

        if (player == Player.Hit)
            return weapon.playerHit;

        return !weapon.playerHit;
    }
}
