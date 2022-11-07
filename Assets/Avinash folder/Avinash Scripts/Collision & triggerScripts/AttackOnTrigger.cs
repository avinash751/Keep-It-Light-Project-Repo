using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOnTrigger : MonoBehaviour
{
    [SerializeField] int AmountOfDamage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IDamagable>() != null)
        {
            IDamagable DamagableObject = other.gameObject.GetComponent<IDamagable>();
            DamagableObject.TakeDamage(AmountOfDamage);
        }
    }

  
}
