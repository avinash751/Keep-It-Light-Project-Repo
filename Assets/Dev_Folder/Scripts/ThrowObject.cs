using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
	PickUpObjectTrigger pickUpTrigger;
	GameObject pickUpObject;
	[Range(500, 1000)]
	[SerializeField] float throwForce;
	Rigidbody objectRb;
	bool hasClicked = false;
	bool throwObject = false;
	void Start()
	{
		pickUpTrigger = GetComponent<PickUpObjectTrigger>();
	}
	void Update()
	{
		Inputs();
	}

	void Inputs()
	{
		if (Input.GetMouseButtonDown(0) && pickUpTrigger.isPickedUp)
		{
			ReferenceLightOrb();
			ThrowOrb();
		}
	}
	void ReferenceLightOrb()
	{
		pickUpObject = pickUpTrigger.orbObject;
		objectRb = pickUpTrigger.objectRb;
	}
	void ThrowOrb()
	{
		throwObject = true;
		objectRb.AddForce(transform.forward * throwForce);
		pickUpTrigger.DropObject();
		Debug.Log("Thrown Item");
	}






}
