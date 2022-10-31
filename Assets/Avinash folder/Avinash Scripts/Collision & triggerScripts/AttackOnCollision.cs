using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class AttackOnCollision : MonoBehaviour
{
    [SerializeField] int AmountOfDamage;
    public bool DoMoreOnCollsion;
    static UnityAction DoExtraOnCollision;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<IDamagable>() != null)
        {
            IDamagable DamagableObject = collision.gameObject.GetComponent<IDamagable>();
            DamagableObject.TakeDamage(AmountOfDamage);
        }
    }
}

    