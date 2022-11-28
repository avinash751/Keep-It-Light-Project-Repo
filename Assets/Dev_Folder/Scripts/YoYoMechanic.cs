using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoYoMechanic : MonoBehaviour
{
	[SerializeField] PickUpObjectTrigger pickUp;
	[SerializeField] LightOrbAmmoCountSystem orbAmmo;
	GameObject pickUpObject;
	Rigidbody objectRb;
	[HideInInspector]
	public bool yoyoShot = false;
	[SerializeField] float maxDistance;
	[SerializeField] float shootingSpeed;
	[SerializeField] float maxSpeed;

	


	void Start()
	{
		pickUp = GetComponent<PickUpObjectTrigger>();
	}

	void Update()
	{
		Inputs();
		RetrunOrb();
	}

	void Inputs()
	{
		if (Input.GetMouseButtonDown(1) && pickUp.isPickedUp)
		{
			ReferenceLightOrb();
			ShootOrb();
			orbAmmo.DecreaseLightOrbAmmo(orbAmmo.ammoUsedWhenYoyoyShot);
			/* StartCoroutine(nameof(ReturnOrbToOriginalPosition)); */
		}

	}

	void ShootOrb()
	{
		if (yoyoShot == false)
		{
			pickUp.DropObject();
			yoyoShot = true;
			objectRb.useGravity = false;
			objectRb.AddForce(transform.forward * 100, ForceMode.Impulse);
			Debug.Log("Shot Orb");
		}
	}

	void RetrunOrb()
	{
		float distanceFromOrb = CalculateDistanceBetweenPlayerAndOrb();
		if (yoyoShot == true && distanceFromOrb > maxDistance)
		{

			objectRb.velocity += ((this.transform.position - objectRb.transform.position).normalized * maxSpeed);
			if (objectRb.velocity.magnitude > maxSpeed)
			{
				objectRb.velocity = (this.transform.position - objectRb.transform.position).normalized * shootingSpeed;

			}
			Debug.Log("Returning");

		}
	}

	float CalculateDistanceBetweenPlayerAndOrb()
	{
		if (yoyoShot == true)
		{
			return Vector3.Distance(this.transform.position, objectRb.transform.position);
		}
		else
		{
			return 0;
		}
	}

	void ReferenceLightOrb()
	{
		pickUpObject = pickUp.orbObject;
		objectRb = pickUp.objectRb;
		orbAmmo = pickUp.OrbAmmo;

	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Light Orb" && yoyoShot)
		{
			pickUp.PickUpObject();
			yoyoShot = false;
		}
	}

	/* IEnumerator ReturnOrbToOriginalPosition()
	{
		yield return new WaitForSeconds(3);
		objectRb.transform.position = transform.position;
	} */

}
