using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPillarAfterDestroyingSpawner : MonoBehaviour
{
	[SerializeField] GameObject pillarSpawn;
	[SerializeField] GameObject enemySpawner;
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
            this.enabled = false;
		}
	}
}
