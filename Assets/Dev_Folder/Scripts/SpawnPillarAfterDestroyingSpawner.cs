using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPillarAfterDestroyingSpawner : MonoBehaviour
{
	[SerializeField] UnityEngine.GameObject pillarSpawn;
	[SerializeField] UnityEngine.GameObject enemySpawner;
	[SerializeField] UnityEngine.GameObject orb;
	[SerializeField] Transform orbTransformToSpawn;
	bool enemySpawnerDies;
	void Start()
	{

	}
	void Update()
	{

		SpawnPillarAfterSpawnerGetsDestroyed();
	}

	void SpawnPillarAfterSpawnerGetsDestroyed()
	{
		if (enemySpawner == null && !enemySpawnerDies)
		{
			enemySpawnerDies = true;
			Instantiate(pillarSpawn, transform.position, Quaternion.identity);
			Instantiate(orb, orbTransformToSpawn.position, Quaternion.identity);
            this.enabled = false;
		}
	}
}
