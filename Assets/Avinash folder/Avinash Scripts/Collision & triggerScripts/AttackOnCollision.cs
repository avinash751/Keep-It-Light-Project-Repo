using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOnCollision : MonoBehaviour
{
    [SerializeField] int AmountOfDamage;
    public string collisionTag;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<IDamagable>() != null && collision.gameObject.CompareTag(collisionTag))
        {
            IDamagable DamagableObject = collision.gameObject.GetComponent<IDamagable>();
            DamagableObject.TakeDamage(AmountOfDamage);
        }
    }
}

    