using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPreSpawnManager : MonoBehaviour
{
    [SerializeField] UnityEngine.GameObject EnemyToSpawn;
    [SerializeField] float NumberOfEnemiesToSpawnOnceAtStart;
    [HideInInspector] public BoxCollider box;


    public virtual void Start()
    {
        box = GetComponent<BoxCollider>();
        SpawnEnemy();
    }


    public virtual void SpawnEnemy()
    {
        for (int i = 0; i <= NumberOfEnemiesToSpawnOnceAtStart; i++)
        {
            Vector3 RandomPosition = GetRandomPositionInBox();
            var EnemyClone = Instantiate(EnemyToSpawn, RandomPosition , transform.rotation);
        }
        Destroy(gameObject);
    }

    Vector3 GetRandomPositionInBox()
    {
        float randomX = Random.Range(box.bounds.min.x, box.bounds.max.x);
        float randomZ = Random.Range(box.bounds.min.z, box.bounds.max.z);

        var randomPosition = new Vector3(randomX,transform.position.y,randomZ);                                
        return randomPosition;
    }


    
}
