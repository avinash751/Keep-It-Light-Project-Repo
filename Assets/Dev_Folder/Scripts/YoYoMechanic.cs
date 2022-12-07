using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoYoMechanic : MonoBehaviour
{
	[SerializeField] PickUpObjectTrigger pickUp;
	[SerializeField] LightOrbAmmoCountSystem orbAmmo;

	GameObject pickUpObject;
	Rigidbody objectRb;


	[SerializeField] float maxDistance;
	[SerializeField] float shootingSpeed;
	[SerializeField] float maxSpeed;
	[SerializeField] float returnTimer;

	[HideInInspector]
	public bool yoyoShot = false;
	bool returnNow = false;


	[Header("sounds")]
	[SerializeField] AudioSource pushSound;



	void Start()
	{
		pickUp = GetComponent<PickUpObjectTrigger>();
	}

	void Update()
	{
		Inputs();
		RetrunOrb();
		ReturnOrbInstantly();
	}

	void Inputs()
	{
		if (Input.GetMouseButtonDown(1) && pickUp.isPickedUp)
		{
			ReferenceLightOrb();
			PlayYoyoPushSound();

			pickUpObject.transform.GetChild(0).transform.GetChild(0).GetComponent<AudioSource>().Play();
			ShootOrb();
			StartCoroutine(ReturnOrbToPlayerPosition());
			orbAmmo.DecreaseLightOrbAmmo(orbAmmo.ammoUsedWhenYoyoyShot);
			pickUp.isPickedUp = true;
		}

	}

	void PlayYoyoPushSound()
	{
		pushSound.pitch = Random.Range(0.75f, 1.5f);
		pushSound.Play();
	}

	void ShootOrb()
	{
		if (yoyoShot == false)
		{
			pickUp.DropObject();
			yoyoShot = true;
			objectRb.useGravity = false;
			objectRb.AddForce(transform.forward * 100, ForceMode.Impulse);
		}
	}

	void RetrunOrb()
	{
		float distanceFromOrb = CalculateDistanceBetweenPlayerAndOrb();
		if (yoyoShot && distanceFromOrb > maxDistance && !returnNow)
		{

			objectRb.velocity += ((this.transform.position - objectRb.transform.position).normalized * maxSpeed);
			if (objectRb.velocity.magnitude > maxSpeed)
			{
				objectRb.velocity = (this.transform.position - objectRb.transform.position).normalized * shootingSpeed;
			}

		}
	}

	void ReturnOrbInstantly()
	{
		if (returnNow)
		{
			objectRb.velocity += ((this.transform.position - objectRb.transform.position).normalized * maxSpeed);
			if (objectRb.velocity.magnitude > maxSpeed)
			{
				objectRb.velocity = (this.transform.position - objectRb.transform.position).normalized * shootingSpeed;
			}
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
			pickUpObject.transform.GetChild(0).transform.GetChild(0).GetComponent<AudioSource>().Stop();
			yoyoShot = false;
			returnNow = false;
		}
	}

	IEnumerator ReturnOrbToPlayerPosition()
	{
		yield return new WaitForSeconds(returnTimer);
		if (yoyoShot)
		{
			returnNow = true;
			Debug.Log("Going Back to player position right now");
		}
	}

}
