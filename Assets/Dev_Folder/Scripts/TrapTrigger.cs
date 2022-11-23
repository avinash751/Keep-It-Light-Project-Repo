using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
	PickUpObjectTrigger triggerTrap;
	bool orbIsPlaced;
	Animator playDoor;
	[SerializeField] string trapDoor;
	void Start()
	{
		triggerTrap = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PickUpObjectTrigger>();
		playDoor = GameObject.FindGameObjectWithTag(trapDoor).GetComponent<Animator>();
	}

	void Update()
	{
		if (!triggerTrap.isPickedUp && orbIsPlaced)
		{
			playDoor.SetTrigger("Door Open");
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Light Orb")
		{
			orbIsPlaced = true;
		}
	}
}
