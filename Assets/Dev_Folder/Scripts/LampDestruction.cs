using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampDestruction : MonoBehaviour
{
	Rigidbody rb;
	bool hitByOrb = false;
	bool hitOnGround = false;
	SphereCollider sphereCollider;
	[SerializeField] float maxRadius;
	void Start()
	{
		sphereCollider = GetComponent<SphereCollider>();
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
			sphereCollider.radius += Time.deltaTime;
			if (sphereCollider.radius > maxRadius)
			{
				sphereCollider.radius = maxRadius;
			}
			for (int i = 0; i < transform.childCount; i++)
			{
				transform.GetChild(i).gameObject.SetActive(false);
			}
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
