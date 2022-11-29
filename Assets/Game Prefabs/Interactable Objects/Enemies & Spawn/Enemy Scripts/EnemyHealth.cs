using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth:ObjectHealth,IDestroyable
{
   [SerializeField] ParticleSystem explode;
   [SerializeField] Value currentPanic;
   [SerializeField] int amountOfPanicToreduce;
    public override void DestroyObject()
    {
        spawnParticleSystem();
        Destroy(gameObject);
        ReducePanic();
       

    }

    void spawnParticleSystem()
    {
        ParticleSystem particle = Instantiate(explode, transform.position + Vector3.up, Quaternion.identity);
        Destroy(particle,3f);
    }

    void ReducePanic()
    {
        if(currentHealth <=0)
        {
            currentPanic.value -= amountOfPanicToreduce;
        }
       
    }

    public void IncreasePanic()
    {
        currentPanic.value += 2;
    }
}
