using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AID_HasCooldownTimePassed : AIDecision
{
    [SerializeField] float timerAdjuster = 5f;

    float timer;

    private void Start()
    {
        timer = timerAdjuster;
    }

    public override bool IsTrue(BrainController owner)
    {
        EnemyWeapon weapon = owner.GetComponentInChildren<EnemyWeapon>();

        timer -= Time.deltaTime;

        Debug.Log(timer);

        if (timer <= 2f)
            weapon.playerHit = false;
        if (timer <= 0f)
        {
            timer = timerAdjuster;
            return true;
        }
        return false;
    }
}
