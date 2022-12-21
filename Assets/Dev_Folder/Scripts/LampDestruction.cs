using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampDestruction : MonoBehaviour
{
	Rigidbody rb;
	bool hitByOrb = false;
	bool hitOnGround = false;
	bool scaleDownLight;
	SphereCollider sphereCollider;
	[SerializeField] float maxRadius;
	[SerializeField] float maxLightRange;
	[SerializeField] float destroyTimer;
	[SerializeField] float lightIntensity;
	[SerializeField] float lightScaleDownMultiplier;
	public ParticleSystem particle;
	[SerializeField] Light light;
	void Start()
	{
		light = GetComponentInChildren<Light>();
		light.intensity = lightIntensity;
		sphereCollider = GetComponent<SphereCollider>();
		rb = GetComponent<Rigidbody>();
		particle = GetComponentInChildren<ParticleSystem>();
		particle.Stop();
		IgnorePlayerCollision();
	}

	void Update()
	{
		if (hitByOrb)
		{
			rb.isKinematic = false;
		}
		ExpandOrbAfterHittingTheGround();

	}	

	void ExpandOrbAfterHittingTheGround()
	{
		if (hitOnGround)
		{
			ExpandRadiusCollision();
			DisableChildrenAfterHittingGround();
			IncreaseLightSizeAfterExplosion();
			ScaleDownLightAfterExplosion();
		}
	}

	void ExpandRadiusCollision()
	{
		sphereCollider.radius += 2 * Time.deltaTime;
		if (sphereCollider.radius > maxRadius)
		{
			sphereCollider.radius = maxRadius;
		}
	}

	void DisableChildrenAfterHittingGround()
	{
		for (int i = 0; i < transform.childCount - 2; i++)
		{
			transform.GetChild(i).gameObject.SetActive(false);
		}
	}

	void IncreaseLightSizeAfterExplosion()
	{
		if (!scaleDownLight)
		{
			light.range += 5 * Time.deltaTime;
			if (light.range > maxLightRange)
			{
				light.range = maxLightRange;
			}
		}
	}

	void ScaleDownLightAfterExplosion()
	{

		light.intensity = Mathf.Lerp(light.intensity, 0.1f, Time.deltaTime * lightScaleDownMultiplier);

	}

	void EnableScalingDownLight()
	{
		scaleDownLight = true;
	}

	void CollisionToHitTheGround()
	{
		light.enabled = true;
		hitOnGround = true;
		var particleExplode = Instantiate(particle, transform.position, Quaternion.identity);
		Destroy(gameObject, destroyTimer);
		Invoke(nameof(EnableScalingDownLight), 1.2f);
	}
	void OnCollisionEnter(Collision other)
	{
	 
		if (other.gameObject.tag == "Light Orb" )
		{
			hitByOrb = true;
		}
		if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Enemy")
		{
			CollisionToHitTheGround();
		}
        
	}

	void IgnorePlayerCollision()
	{
		var playerCollider = FindObjectOfType<FpsMovment>().gameObject.GetComponent<Collider>();
		var handCollider = UnityEngine.GameObject.Find("hand holder").GetComponent<Collider>() ;

        Physics.IgnoreCollision(playerCollider, gameObject.GetComponent<Collider>(), true);
        Physics.IgnoreCollision(handCollider, gameObject.GetComponent<Collider>(), true);
    }

}
