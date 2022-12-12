using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastEffect : MonoBehaviour
{
	public ParticleSystem particleSystem;

	bool playEffect = false;
	bool hitByOrb = false;

	void Start()
	{
		/* particleSystem = GetComponentInChildren<ParticleSystem>(); */
	}

	void Update()
	{

		PlayBlastEffect();
	}

	void PlayBlastEffect()
	{
		if (hitByOrb && !playEffect)
		{
			playEffect = true;

		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Light Orb")
		{
			var orb = other.gameObject.GetComponent<DarkOrbDestroyer>();
			if (orb.YoyoShot || orb.IsThrown)
			{
				hitByOrb = true;
				particleSystem.Play();
				var particleClone = Instantiate(particleSystem, transform.position, Quaternion.identity);
				particleClone.transform.parent = transform;
				Destroy(particleClone.gameObject, 1f);
			}
		}
	}
}
