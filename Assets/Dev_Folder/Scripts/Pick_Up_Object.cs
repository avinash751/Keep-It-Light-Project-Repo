using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up_Object : MonoBehaviour
{

	[SerializeField] Transform holdArea;
	private GameObject heldObj;
	Rigidbody heldObjRb;

	[SerializeField] float pickupRange;
	[SerializeField] float pickupForce;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			if (heldObj == null)
			{
				RaycastHit hit;
				if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
				{
					PickupObject(hit.transform.gameObject);
				}
			}
			else
			{
				DropObject();
			}
		}
		if (heldObj != null)
		{
            MoveObject();
		}
        
	}

	void MoveObject()
	{
		if (Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f)
		{
            Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
            heldObjRb.AddForce(moveDirection * pickupForce);
			
		}
	}

	void PickupObject(GameObject pickObj)
	{
		if (pickObj.GetComponent<Rigidbody>())
		{
			heldObjRb = pickObj.GetComponent<Rigidbody>();
			heldObjRb.useGravity = false;
			heldObjRb.drag = 10;
			heldObjRb.constraints = RigidbodyConstraints.FreezeRotation;
			heldObjRb.transform.position = holdArea.position;
			heldObjRb.transform.parent = holdArea;
			heldObj = pickObj;
		}
	}
	void DropObject()
	{

		heldObjRb.useGravity = true;
		heldObjRb.drag = 1;
		heldObjRb.constraints = RigidbodyConstraints.None;

		heldObjRb.transform.parent = null;
		heldObj = null;
	}

}
