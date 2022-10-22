using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour,IDamagable
{
    public Value Health, MaxHealth;
   
    void Start()
    {
       InitialisingValues();
    }

    public void TakeDamage(int Amount)
    {
        Health.value -= Amount;
    }


    void InitialisingValues()
    {
        Health.value = 0;
        Health.value = MaxHealth.value;
    }
}
