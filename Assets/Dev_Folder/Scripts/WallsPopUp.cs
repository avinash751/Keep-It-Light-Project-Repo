using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsPopUp : MonoBehaviour
{
	[SerializeField] GameObject enemySpawn;
	[SerializeField] GameObject walls;

	void Update()
	{
		if (enemySpawn == null)
		{
			walls.SetActive(true);
		}
	}

}
