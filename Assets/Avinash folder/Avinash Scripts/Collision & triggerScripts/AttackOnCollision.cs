using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackOnCollision : MonoBehaviour
{
    [SerializeField] int AmountOfDamage;
    public string collisionTag;
    public UnityEvent DoExtraOnCollsion;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<IDamagable>() != null && collision.gameObject.CompareTag(collisionTag))
        {
            DoExtraOnCollsion.Invoke();
            IDamagable DamagableObject = collision.gameObject.GetComponent<IDamagable>();
            DamagableObject.TakeDamage(AmountOfDamage);
           
        }
    }
}

    