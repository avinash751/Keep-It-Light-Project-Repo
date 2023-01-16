using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableScripts : MonoBehaviour
{
	[SerializeField] GameObject enemy;
	// Start is called before the first frame update
	void Start()
	{
		enemy.SetActive(false);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			enemy.SetActive(true);
		}
	}
}
