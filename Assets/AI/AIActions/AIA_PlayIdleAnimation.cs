using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIA_PlayIdleAnimation : AIAction
{
    public override void Act(BrainController owner)
    {
        owner.GetComponent<Animator>().Play("Ogre_Idle_Anim");
    }
}
