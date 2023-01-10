using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjectTrigger : MonoBehaviour
{
	[HideInInspector]
	public UnityEngine.GameObject orbObject;
	[HideInInspector]
	public Rigidbody objectRb;
	public bool hasClicked = false;

	
	public bool isPickedUp = false;
	[SerializeField] Transform holdTransform;
	[SerializeField] public YoYoMechanic yoyoShot;
	[HideInInspector] public LightOrbAmmoCountSystem OrbAmmo;
	[HideInInspector] public AmmoColorLerper orbColor;
    [SerializeField, HideInInspector]
	ThrowObject throwOrb;


	private void Start()
	{
		throwOrb = GetComponent<ThrowObject>();
		OrbAmmo = GetComponent<LightOrbAmmoCountSystem>();
		yoyoShot = GetComponent<YoYoMechanic>();

	}
	void Update()
	{
		Inputs();
	}

	void Inputs()
	{
		if (Input.GetKeyDown(KeyCode.E) && hasClicked == true && !isPickedUp)
		{
			throwOrb.throwObject = false;
			PickUpObject();
		}
		else if (Input.GetKeyDown(KeyCode.E) && isPickedUp)
		{

			DropObject();
			orbObject = null;
		}


	}

	public void PickUpObject()
	{
		orbObject.GetComponent<TrailRenderer>().time = 0;
		//Debug.Log("Picked up item");
		orbObject.transform.position = holdTransform.position;
		orbObject.transform.SetParent(this.transform);
		objectRb.useGravity = false;
		objectRb.constraints = RigidbodyConstraints.FreezeAll;
		objectRb.mass = 1;
        isPickedUp = true;
		orbObject.GetComponent<DarkOrbDestroyer>().OrbEquipSound.Play();
		orbColor.StopGlowOrb();
	}

	public void DropObject()
	{
		orbObject.GetComponent<TrailRenderer>().time = 0.35f;
		hasClicked = false;
		objectRb.useGravity = true;
		isPickedUp = false;
		orbColor.PlayLightOrbAnimations(true, false);
        objectRb.constraints = RigidbodyConstraints.None;
        orbObject.GetComponent<DarkOrbDestroyer>().OrbEquipSound.Stop();
        objectRb.mass = 1250;
        orbObject.transform.SetParent(null);
		OrbAmmo = null;
		orbColor = null;
		orbObject = null;
	

	}
	public void DropObjectWhenYoyo()
	{
        orbObject.GetComponent<TrailRenderer>().time = 0.35f;
        objectRb.useGravity = true;
        isPickedUp = false;
        orbObject.transform.SetParent(null);
        objectRb.constraints = RigidbodyConstraints.None;
        orbObject.GetComponent<DarkOrbDestroyer>().OrbEquipSound.Stop();
    }
	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Light Orb" && !isPickedUp && !yoyoShot.yoyoShot && !hasClicked)
		{
			ReferencePartsOfTheLightOrb(other.gameObject);
			
			hasClicked = true;
			LightOrbAnimationOntrigger();
               
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Light Orb" && !isPickedUp)
		{
			hasClicked = false;

			LightOrbAnimationOnTriggerExit();
          
        }
	}

	void ReferencePartsOfTheLightOrb(GameObject lightOrbInTrigger)
	{
        orbObject = lightOrbInTrigger.gameObject;
        objectRb = orbObject.GetComponent<Rigidbody>();
        OrbAmmo = orbObject.GetComponent<LightOrbAmmoCountSystem>();
        orbColor = orbObject.GetComponent<AmmoColorLerper>();
    }

	void LightOrbAnimationOntrigger()
	{
        if (!OrbAmmo.IsAmmoZero() && orbColor!=null)
        {
            orbColor.PlayLightOrbAnimations(false, true);
        }
        else
        {
            orbColor.PlayLightOrbAnimations(false, false);
            
        }
    }

	void LightOrbAnimationOnTriggerExit()
	{
        if (!OrbAmmo.IsAmmoZero() && orbColor != null)
        {
            orbColor?.PlayLightOrbAnimations(true, false);
        }
        else
        {
            orbColor.PlayLightOrbAnimations(false, false);

        }
    }



	
}
