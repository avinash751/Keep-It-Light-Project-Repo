using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth:ObjectHealth,IDestroyable
{
   [SerializeField] ParticleSystem explode;
    public override void DestroyObject()
    {
        spawnParticleSystem();
        Destroy(gameObject);
    }

    void spawnParticleSystem()
    {
        ParticleSystem particle = Instantiate(explode, transform.position + Vector3.up, Quaternion.identity);
        Destroy(particle,3f);
    }
}
