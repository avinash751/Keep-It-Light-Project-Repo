using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth:ObjectHealth,IDestroyable
{
    public override void DestroyObject()
    {
        Destroy(gameObject);
    }
}
