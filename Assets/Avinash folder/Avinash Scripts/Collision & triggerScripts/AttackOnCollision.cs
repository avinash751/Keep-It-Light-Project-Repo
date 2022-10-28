using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOnCollision : MonoBehaviour
{
    [SerializeField] int AmountOfDamage;
    public bool DoMoreOnCollsion;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<IDamagable>() != null)
        {
            IDamagable DamagableObject = collision.gameObject.GetComponent<IDamagable>();
            DamagableObject.TakeDamage(AmountOfDamage);
        }
    }
}

    