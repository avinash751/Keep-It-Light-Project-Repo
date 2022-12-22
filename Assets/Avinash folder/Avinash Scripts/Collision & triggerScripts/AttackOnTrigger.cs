using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOnTrigger : MonoBehaviour
{
    [SerializeField] int AmountOfDamage;
    [SerializeField] string collisionTag;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IDamagable>() != null && other.gameObject.tag == collisionTag)
        {
            IDamagable DamagableObject = other.gameObject.GetComponent<IDamagable>();
            DamagableObject.TakeDamage(AmountOfDamage);
        }
    }

  
}
