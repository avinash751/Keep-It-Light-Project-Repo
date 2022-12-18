using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesAfterDestroyingSpawner : EnemyPreSpawnManager
{
	[SerializeField] GameObject enemySpawner;
	bool spawnOnce;

	public override void Start()
	{
		box = GetComponent<BoxCollider>();
	}

	void Update()
	{
		WhenSpawnerIsNullSpawnEnemies();
	}

	void WhenSpawnerIsNullSpawnEnemies()
	{
		if (enemySpawner == null && !spawnOnce)
		{
			SpawnEnemy();
			spawnOnce = true;
		}

	}
}
