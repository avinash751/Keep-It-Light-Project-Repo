using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformUpwardsToSecondFloor : MonoBehaviour
{
	[SerializeField] UnityEngine.GameObject player;
	Animator movePlatform;
	bool playerInRange = false;

	void Start()
	{
		movePlatform = GetComponentInParent<Animator>();
	}
	void Update()
	{
		if (playerInRange)
		{
			movePlatform.SetBool("MovePlatformInAnyOfTheThreeDirections", true);
            player.GetComponent<Rigidbody>().mass = 1;
		}
        else if(!playerInRange)
        {
             player.GetComponent<Rigidbody>().mass = 1000;
        }
	}

	void OnTriggerEnter(Collider other)
	{
		player = other.gameObject;

		if (player)
		{
			playerInRange = true;
		}
	}
    void OnTriggerExit(Collider other)
    {
        player = other.gameObject;
        playerInRange = false;
    }

}
