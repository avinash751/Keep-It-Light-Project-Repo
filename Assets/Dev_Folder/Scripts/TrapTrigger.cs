using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
	PickUpObjectTrigger triggerTrap;
	bool orbIsPlaced;
	Animator playDoor;
	[SerializeField] string trapDoor;
	BoxCollider collider;
	void Start()
	{
		collider = GetComponent<BoxCollider>();
		triggerTrap = FindObjectOfType<PickUpObjectTrigger>();
		playDoor = GameObject.FindGameObjectWithTag(trapDoor).GetComponent<Animator>();
	}

	void Update()
	{
		if (triggerTrap.orbObject == null && orbIsPlaced)
		{
			playDoor.SetTrigger("Door Open");
			foreach(Transform child in transform)
			{
				GameObject.Destroy(child.gameObject, 1f);
			}
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Light Orb")
		{
			orbIsPlaced = true;
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (triggerTrap.orbObject == null && other.gameObject.tag == "Light Orb")
		{
			other.transform.SetParent(collider.gameObject.transform);
			other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
		}
	}
}
