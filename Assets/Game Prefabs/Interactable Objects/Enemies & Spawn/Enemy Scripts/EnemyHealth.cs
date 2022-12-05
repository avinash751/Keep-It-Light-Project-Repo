using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth:ObjectHealth,IDestroyable
{
   [SerializeField] ParticleSystem explode;
   public Value currentPanic;
   [SerializeField] int PanicToreduceOnDestroy;
   [SerializeField] AudioClip soundOnDestroy;
   [SerializeField] float soundVolume;

    public override void DestroyObject()
    {
        spawnParticleSystem();
        
        ReducePanic(PanicToreduceOnDestroy);
        
        AudioSource.PlayClipAtPoint(soundOnDestroy, transform.position, soundVolume);
        
        Destroy(gameObject);


    }

    void spawnParticleSystem()
    {
        ParticleSystem particle = Instantiate(explode, transform.position + Vector3.up, Quaternion.identity);
        Destroy(particle,3f);
    }


    // panic code 

    public void ReducePanic(int amount)
    {
        if(currentHealth <=0)
        {
            currentPanic.value -= amount;
        }
       
    }

    public void IncreasePanic(int amount)
    {
        currentPanic.value += amount;
    }
}
