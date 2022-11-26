using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLightShield : MonoBehaviour
{
	CapsuleCollider shieldCapsule;
	PickUpObjectTrigger pickUpTrigger;
	[SerializeField] float shieldRadius;
	[SerializeField] GameObject shieldAura;
	[SerializeField] Transform playerPos;
	bool isShielded = false;

	void Start()
	{
		shieldCapsule = GetComponent<CapsuleCollider>();
		pickUpTrigger = GetComponent<PickUpObjectTrigger>();

	}
	void Update()
	{
		ActivateShieldWhenPlayerPicksUpOrb();
	}

	void ActivateShieldWhenPlayerPicksUpOrb()
	{
		if (pickUpTrigger.isPickedUp && !isShielded)
		{
			shieldCapsule.radius = shieldRadius;
			Instantiate(shieldAura, playerPos.transform.position, transform.rotation);
			shieldAura.transform.position = playerPos.position;
			isShielded = true;
		}
        else if(!pickUpTrigger.isPickedUp)
        {
           shieldCapsule.radius = 0.1f;
        }
	}
}
