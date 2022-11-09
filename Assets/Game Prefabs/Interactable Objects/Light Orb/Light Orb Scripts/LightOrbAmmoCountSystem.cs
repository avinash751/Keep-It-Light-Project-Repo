using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOrbAmmoCountSystem : MonoBehaviour
{
    private PickUpObjectTrigger pickUp;
    private YoYoMechanic yoyo;
    private GameObject lightOrbInUse;
    public GameObject AmmoText;
    [SerializeField] Value lightOrbsDestroyed;

    [SerializeField] Value maxAmmo;
    public  Value currentAmmo;
   
    void Start()
    {
        pickUp = GetComponent<PickUpObjectTrigger>();
        yoyo = GetComponent<YoYoMechanic>();
        ResetAmmo();
        AmmoText.SetActive(false);
    }

    
    void Update()
    {
       
    }

    public void DecreaseAmmoWhenShot(int amount)
    {
        if(currentAmmo.value > 0 )
        {
            currentAmmo.value-=amount;
            currentAmmo.value = Mathf.Clamp(currentAmmo.value, 0, 100);
        }
    }

    public IEnumerator KillOrbWhenAmmoZeroAndShot(float delay,GameObject orbToDestroy)
    {
        if(currentAmmo.value<=0 )
        {
            yield return new WaitForSeconds(delay);

            IncrementTheNumberOflightOrbsDestroyed();
            Destroy(orbToDestroy);

            if(lightOrbInUse!=orbToDestroy && pickUp.isPickedUp)
            {
                AmmoText.SetActive(true);
            }
            else if(lightOrbInUse == orbToDestroy && pickUp.isPickedUp)
            {
                AmmoText.SetActive(false);
                pickUp.DropObject();
            }
        }
    }

    void IncrementTheNumberOflightOrbsDestroyed()
    {
        lightOrbsDestroyed.value++;
    }

    void ResetAmmo()
    {
        currentAmmo.value = maxAmmo.value;
    }

    public void AssignLightOrbAndResetAmmo(GameObject newlightOrb)
    {
        if (newlightOrb != lightOrbInUse || lightOrbInUse==null)
        {
            ResetAmmo();
            lightOrbInUse = newlightOrb;
            AmmoText.SetActive(true);
        }
    }


    
}
