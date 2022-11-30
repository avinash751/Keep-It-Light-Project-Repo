using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour,IDamagable,IDestroyable
{
    public Value  MaxHealth;
    public  float currentHealth;
   
    void Start()
    {
       InitialisingValues();
    }

    public void TakeDamage(int Amount)
    {
        currentHealth = Mathf.Clamp(currentHealth, 1, MaxHealth.value);
        currentHealth -= Amount;
        
        if(currentHealth <=0)
        {
            DestroyObject();
        }
    }

    public virtual void DestroyObject()
    {
        Debug.Log("object is dead");
    }


    void InitialisingValues()
    {
        currentHealth = 0;
        currentHealth = MaxHealth.value;
    }
}
