using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
	PickUpObjectTrigger pickUpTrigger;
	LightOrbAmmoCountSystem orbAmmo;
	GameObject pickUpObject;
	[Range(500, 1000)]
	[SerializeField] float throwForce;
	Rigidbody objectRb;
	bool hasClicked = false;
	[HideInInspector]
	public bool throwObject = false;
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
			orbAmmo.DecreaseLightOrbAmmo(orbAmmo.ammoUsedWhenThrown);
		}
	}
	void ReferenceLightOrb()
	{
		pickUpObject = pickUpTrigger.orbObject;
		objectRb = pickUpTrigger.objectRb;
		orbAmmo = pickUpTrigger.OrbAmmo;
	}
	void ThrowOrb()
	{
		throwObject = true;
		objectRb.AddForce(transform.forward * throwForce);
		pickUpTrigger.DropObject();
		Debug.Log("Thrown Item");
	}






}
