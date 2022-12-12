using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlastRadius : MonoBehaviour
{
	[SerializeField] float radiusExpansion;
	[SerializeField] float decreaseRadius;
	[SerializeField] float startRadius;
	[SerializeField] float maxRadius;
	[SerializeField] float timer;
	SphereCollider collider;
	bool hitByOrb = false;
	bool grow = false;

	void Start()
	{
		collider = GetComponent<SphereCollider>();
		collider.radius = startRadius;
	}

	void Update()
	{
		HittingOrbStartsRadiusExpansion();
	}

	void HittingOrbStartsRadiusExpansion()
	{
		if (hitByOrb)
		{
			ExpandRadiusWhenHitByOrb();
			DecreaseRadiusOnceItReachedMaxRadius();
		}
	}

	void ExpandRadiusWhenHitByOrb()
	{
		if (grow)
		{
			collider.radius += radiusExpansion * Time.deltaTime;
		}
		if (collider.radius > maxRadius)
		{
			collider.radius = maxRadius;
		}
	}

	void DecreaseRadiusOnceItReachedMaxRadius()
	{
		if (!grow)
		{
			collider.radius = Mathf.Lerp(collider.radius, 0.1f, Time.deltaTime * decreaseRadius);
		}
	}

	void DisableGrowing()
	{
		grow = false;
		Debug.Log("Decreasing collider size");
	}
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Light Orb")
		{
			var orb = other.gameObject.GetComponent<DarkOrbDestroyer>();
			if (orb.YoyoShot || orb.IsThrown)
			{
				hitByOrb = true;
				grow = true;
				Invoke(nameof(DisableGrowing), timer);
			}
		}
	}
}
