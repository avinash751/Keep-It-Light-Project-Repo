using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjectTrigger : MonoBehaviour
{
	[HideInInspector]
	public GameObject orbObject;
	[HideInInspector]
	public Rigidbody objectRb;
	public bool hasClicked = false;
	[HideInInspector]
	public bool isPickedUp = false;
	[SerializeField] Transform holdTransform;
    [HideInInspector] public  LightOrbAmmoCountSystem OrbAmmo;
	[SerializeField, HideInInspector]
	ThrowObject throwOrb;

	private void Start()
	{
		orbAmmo = GetComponent<LightOrbAmmoCountSystem>();
	private void Start()
	{
		throwOrb = GetComponent<ThrowObject>();
		
	}
	void Update()
	{
		Inputs();
	}

	void Inputs()
	{
		if (Input.GetKeyDown(KeyCode.E) && hasClicked == true && !isPickedUp)
		{
			throwOrb.throwObject = false;
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
		orbObject.GetComponent<TrailRenderer>().time = 0;
		//Debug.Log("Picked up item");
		orbObject.transform.position = holdTransform.position;
		orbObject.transform.SetParent(this.transform);
		objectRb.useGravity = false;
		objectRb.constraints = RigidbodyConstraints.FreezeAll;
		isPickedUp = true;
	}

	public void DropObject()
	{
        orbObject.GetComponent<TrailRenderer>().time = 0.35f;
        //Debug.Log("Dropped Item");
        hasClicked = false;
		objectRb.useGravity = true;
		isPickedUp = false;
		orbObject.transform.SetParent(null);
		OrbAmmo = null;
		objectRb.constraints = RigidbodyConstraints.None;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Light Orb" && !isPickedUp)
		{
			orbObject = other.gameObject;
			objectRb = orbObject.GetComponent<Rigidbody>();
			OrbAmmo = orbObject.GetComponent<LightOrbAmmoCountSystem>();
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
