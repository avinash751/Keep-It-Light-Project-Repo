using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLightShield : MonoBehaviour
{
	CapsuleCollider shieldCapsule;
	PickUpObjectTrigger pickUpTrigger;
	[SerializeField] float shieldRadius;

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
		if (pickUpTrigger.isPickedUp)
		{
			shieldCapsule.radius = shieldRadius;
			Debug.Log("ACTIVATING SHIELD");
		}
        else if(!pickUpTrigger.isPickedUp)
        {
           shieldCapsule.radius = 0.1f;
        }
	}
}