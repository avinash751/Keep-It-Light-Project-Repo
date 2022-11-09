using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoYoMechanic : MonoBehaviour
{
	[SerializeField] PickUpObjectTrigger pickUp;
	LightOrbAmmoCountSystem lightOrbAmmo;
	GameObject pickUpObject;
	Rigidbody objectRb;
	[HideInInspector]
	public bool yoyoShot = false;
	[SerializeField] float maxDistance;
	[SerializeField] float shootingSpeed;

	void Start()
	{
		pickUp = GetComponent<PickUpObjectTrigger>();
		lightOrbAmmo = GetComponent<LightOrbAmmoCountSystem>();
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
			
		}

	}

	void ShootOrb()
	{
		if (yoyoShot == false)
		{
			lightOrbAmmo.DecreaseAmmoWhenShot(1);
            yoyoShot = true;
            pickUp.DropObject();
			objectRb.AddForce(transform.forward * 100, ForceMode.Impulse);
			Debug.Log("Shot Orb");
		}
	}

	void RetrunOrb()
	{
		float distanceFromOrb = CalculateDistanceBetweenPlayerAndOrb();
		if (yoyoShot == true && distanceFromOrb > maxDistance)
		{
			objectRb.velocity = (this.transform.position - objectRb.transform.position) * shootingSpeed;
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

	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Light Orb" && yoyoShot)
		{
            pickUp.PickUpObject();
			yoyoShot = false;
			StartCoroutine(lightOrbAmmo.KillOrbWhenAmmoZeroAndShot(0,pickUpObject));
		}
	}
}
