using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToSpawn : EnemyPreSpawnManager
{

    override public void Start()
    {
        box = GetComponent<BoxCollider>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out FpsMovment player))
        {
            SpawnEnemy();
        }
    }
}
