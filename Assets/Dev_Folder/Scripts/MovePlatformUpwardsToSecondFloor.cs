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
			movePlatform.SetBool("MovePlatform", true);
		}
	}

	void DelayToMakePlayerInRangeTrue()
	{
		playerInRange = true;
	}

	void OnTriggerEnter(Collider other)
	{
		if (player)
		{
			Invoke(nameof(DelayToMakePlayerInRangeTrue), 1f);
		}
	}
    void OnTriggerExit(Collider other)
    {
        playerInRange = false;
    }
	

}
