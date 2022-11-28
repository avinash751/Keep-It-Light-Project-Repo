using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBlast : MonoBehaviour
{
	YoYoMechanic orb;
	bool hitEnemy = false;
	bool hasKnockedEnemies = false;
	[SerializeField] GameObject explosionEffect;
	[SerializeField] float radius;
	[SerializeField] float explosionForce;

	void Start()
	{
		orb = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<YoYoMechanic>();
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
		Instantiate(explosionEffect, transform.position, transform.rotation);
		Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

		foreach (Collider nearbyObject in colliders)
		{
			Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
			if(rb != null)
			{
				rb.AddExplosionForce(explosionForce, transform.position, radius);
			}
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			explosionEffect.GetComponentInChildren<ParticleSystem>().Play();
			hitEnemy = true;
		}
	}
}
