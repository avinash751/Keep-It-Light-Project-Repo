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
		orbAmmo = GetComponent<LightOrbAmmoCountSystem>();
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
            orbAmmo.DecreaseAmmoWhenShot(2);
            StartCoroutine(orbAmmo.KillOrbWhenAmmoZeroAndShot(3.5f,pickUpObject));
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
