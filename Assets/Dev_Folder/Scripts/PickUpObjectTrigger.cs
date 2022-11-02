using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjectTrigger : MonoBehaviour
{
	[SerializeField] GameObject pickUpObject;
	[SerializeField] float throwForce;
    Rigidbody objectRb;
	public bool hasClicked = false;
    bool throwObject = false;


	void Start()
	{
		

	}

	void Update()
	{
		Inputs();
	}

	void Inputs()
	{
		if (Input.GetKeyDown(KeyCode.E) && hasClicked == true)
		{
			EnablePickUp();
            
		}
		else if (Input.GetKeyDown(KeyCode.G))
		{
			DisablePickUp();
		}
        if(Input.GetMouseButtonDown(0) && hasClicked == true)
        {
            ThrowObject();
            throwObject = false;
        }

	}

    void ThrowObject()
    {
        throwObject = true;
        objectRb.AddForce(transform.forward * throwForce);
        objectRb.useGravity = true;
        pickUpObject.transform.parent = null;
        hasClicked = false;
        objectRb.constraints = RigidbodyConstraints.None;   
        Debug.Log("Thrown Item");

    }

	void EnablePickUp()
	{
		Debug.Log("Picked up item");
		pickUpObject.transform.SetParent(this.transform);
		objectRb.useGravity = false;
		objectRb.constraints = RigidbodyConstraints.FreezePosition;

	}

	void DisablePickUp()
	{
		Debug.Log("Dropped Item");
		hasClicked = false;
		objectRb.useGravity = true;
		pickUpObject.transform.SetParent(null);
		objectRb.constraints = RigidbodyConstraints.None;
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Light Orb")
		{
			pickUpObject = other.gameObject;
			objectRb = pickUpObject.GetComponent<Rigidbody>();
			hasClicked = true;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Light Orb")
		{
			hasClicked = false;
			pickUpObject = null;
		}
	}
}
