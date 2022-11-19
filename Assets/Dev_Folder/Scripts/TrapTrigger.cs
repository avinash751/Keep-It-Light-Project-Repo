using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
	public PickUpObjectTrigger triggerTrap;
    bool orbIsPlaced;
    Animator playDoor;
	void Start()
	{
		triggerTrap = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PickUpObjectTrigger>();
        playDoor = GameObject.FindGameObjectWithTag("Trap Door").GetComponent<Animator>();
	}

	void Update()
	{
		if (!triggerTrap.isPickedUp && orbIsPlaced)
		{
            Debug.Log("Activating Door");
            playDoor.SetTrigger("Door Open");
		}
	}
	void OnTriggerEnter(Collider other)
	{
        if(other.gameObject.tag == "Light Orb")
        {
            orbIsPlaced = true;
        }
	}
}
