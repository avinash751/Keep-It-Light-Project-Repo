using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorAfterEnemySpawnDies : MonoBehaviour
{
	[SerializeField] UnityEngine.GameObject enemySpawner;
	Animator openDoor;
	void Start()
	{
		openDoor = GetComponent<Animator>();
	}
	void Update()
	{
		if (enemySpawner == null)
		{
			openDoor.SetBool("OpenDoor", true);
			Debug.Log("Opening door");
		}
	}
}
