using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OrbOnCollsion :AttackOnCollision
{
    DarkOrbDestroyer orb;
   

    private void Start()
    {
        orb = GetComponent<DarkOrbDestroyer>();
    }
    public override void Attack(UnityEngine.GameObject collsionObject)
    {
        if(orb.trigger.orbObject == gameObject)
        {
            AttackEnemyWhenShotOrThrown(collsionObject);
        }
       
    }

    void AttackEnemyWhenShotOrThrown(UnityEngine.GameObject obj)
    {
        if (orb.YoyoShot || orb.IsThrown )
        {
            base.Attack(obj);
        }
    }
}
