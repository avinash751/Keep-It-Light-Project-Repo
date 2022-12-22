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
            Attack(collision.gameObject);
        }
    }

    public virtual void  Attack(UnityEngine.GameObject collsionObject)
    {
        DoExtraOnCollsion.Invoke();
        IDamagable DamagableObject = collsionObject.GetComponent<IDamagable>();
        DamagableObject.TakeDamage(AmountOfDamage);
    }
}

    