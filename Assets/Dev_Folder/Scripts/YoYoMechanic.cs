using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoYoMechanic : MonoBehaviour
{
	[SerializeField] PickUpObjectTrigger pickUp;
	[SerializeField] LightOrbAmmoCountSystem orbAmmo;

    UnityEngine.GameObject pickUpObject;
	Rigidbody objectRb;


	[SerializeField] float maxDistance;
	[SerializeField] float shootingSpeed;
    [SerializeField] float initialPushForce;
    [SerializeField] float maxSpeed;
	[SerializeField] float returnTimer;

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
            pickUp.orbColor.gloworb();
			pickUp.DropObjectWhenYoyo();
			yoyoShot = true;
			objectRb.useGravity = false;
			objectRb.AddForce(transform.forward * initialPushForce, ForceMode.Impulse);
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
	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Light Orb" && yoyoShot && returnNow)
		{
			pickUp.PickUpObject();
			pickUpObject.transform.GetChild(0).transform.GetChild(0).GetComponent<AudioSource>().Stop();
			pickUp.OrbAmmo = pickUp.orbObject.GetComponent<LightOrbAmmoCountSystem>();
            pickUp.orbColor.StopGlowOrb();
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
