using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampDestruction : MonoBehaviour
{
	Rigidbody rb;
	bool hitByOrb = false;
	bool hitOnGround = false;
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (hitByOrb)
		{
			rb.useGravity = true;
		}
		if (hitOnGround)
		{
			Destroy(this.gameObject, 0.25f);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Light Orb")
		{
			hitByOrb = true;
		}

		if (other.gameObject.tag == "Ground")
		{
			hitOnGround = true;
		}
	}
}
