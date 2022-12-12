using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBlast : MonoBehaviour
{
	YoYoMechanic orb;
	bool hitEnemy = false;
	bool hasKnockedEnemies = false;

	[SerializeField] float radius;
	[SerializeField] float explosionForce;

	void Start()
	{
		orb = GameObject.FindObjectOfType<YoYoMechanic>();
	}

	void Update()
	{
		BlastEnemiesWhenTheyCollide();
	}

	void BlastEnemiesWhenTheyCollide()
	{
		if (orb.yoyoShot == true && hitEnemy && !hasKnockedEnemies)
		{
			BlastEffect();
			hasKnockedEnemies = true;
		}
	}

	void BlastEffect()
	{
		Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

		foreach (Collider nearbyObject in colliders)
		{
			Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
			if (rb != null)
			{
				rb.AddExplosionForce(explosionForce, transform.position, radius);
			}
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			hitEnemy = true;
		}
	}
	void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, radius);
	}
}
