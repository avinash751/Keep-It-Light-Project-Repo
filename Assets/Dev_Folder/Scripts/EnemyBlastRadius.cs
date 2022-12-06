using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlastRadius : MonoBehaviour
{
	[SerializeField] float radiusExpansion;
	[SerializeField] float startRadius;
	[SerializeField] float maxRadius;
	SphereCollider collider;
	bool hitByOrb = false;
	void Start()
	{
		collider = GetComponent<SphereCollider>();
		collider.radius = startRadius;
	}

	void Update()
	{
		ExpandRadiusWhenHitByOrb();
	}

	void ExpandRadiusWhenHitByOrb()
	{
		if (hitByOrb)
		{
			collider.radius += radiusExpansion * Time.deltaTime;
		}
		if (hitByOrb && collider.radius > maxRadius)
		{
			collider.radius = 0;
            hitByOrb = false;
		}
	}
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Light Orb")
		{
			hitByOrb = true;
		}
	}
}
