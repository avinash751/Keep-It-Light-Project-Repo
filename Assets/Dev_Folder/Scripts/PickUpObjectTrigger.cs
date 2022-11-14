using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjectTrigger : MonoBehaviour
{
	[HideInInspector]
	public GameObject orbObject;
	LightOrbAmmoCountSystem orbAmmo;
	[HideInInspector]
	public Rigidbody objectRb;
	public bool hasClicked = false;
	[HideInInspector]
	public bool isPickedUp = false;
	bool throwObject = false;
	[SerializeField] Transform holdTransform;

	private void Start()
	{
		orbAmmo = GetComponent<LightOrbAmmoCountSystem>();
	}
	void Update()
	{
		Inputs();
	}

	void Inputs()
	{
		if (Input.GetKeyDown(KeyCode.E) && hasClicked == true && !isPickedUp)
		{
			PickUpObject();
		}
		else if (Input.GetKeyDown(KeyCode.E) && isPickedUp)
		{

			DropObject();
			orbObject = null;
		}


	}

	public void PickUpObject()
	{
		orbAmmo.AssignLightOrbAndResetAmmo(orbObject);
		Debug.Log("Picked up item");
		orbObject.transform.position = holdTransform.position;
		orbObject.transform.SetParent(this.transform);
		objectRb.useGravity = false;
		objectRb.constraints = RigidbodyConstraints.FreezeAll;
		isPickedUp = true;
	}

	public void DropObject()
	{
		Debug.Log("Dropped Item");
		hasClicked = false;
		objectRb.useGravity = true;
		isPickedUp = false;
		orbObject.transform.SetParent(null);
		objectRb.constraints = RigidbodyConstraints.None;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Light Orb" && !isPickedUp)
		{
			orbObject = other.gameObject;
			objectRb = orbObject.GetComponent<Rigidbody>();
			hasClicked = true;
		}

	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Light Orb" && !isPickedUp)
		{
			hasClicked = false;
		}
	}
}
