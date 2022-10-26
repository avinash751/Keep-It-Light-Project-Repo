using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour,IDamagable,IDestroyable
{
    public Value Health, MaxHealth;
   
    void Start()
    {
       InitialisingValues();
    }

    public void TakeDamage(int Amount)
    {
        Health.value = Mathf.Clamp(Health.value, 1, MaxHealth.value);
        Health.value -= Amount;
        
        if(Health.value <=0)
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
        Health.value = 0;
        Health.value = MaxHealth.value;
    }
}
