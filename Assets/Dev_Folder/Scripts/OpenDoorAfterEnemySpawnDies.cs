using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorAfterEnemySpawnDies : MonoBehaviour
{
	[SerializeField] GameObject enemySpawner;
	Animator openDoor;
	void Start()
	{
		openDoor = GetComponent<Animator>();
	}
	void Update()
	{
		if (enemySpawner == null)
		{
			openDoor.SetBool("Open Door", true);
		}
	}
}
