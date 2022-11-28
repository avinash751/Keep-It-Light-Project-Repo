using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOrbAmmoCountSystem : MonoBehaviour
{
    [SerializeField, HideInInspector] DarkOrbDestroyer LightOrb;
    [SerializeField, HideInInspector] AmmoColorLerper lerpColor;
    [SerializeField] Value lightOrbsDestroyed;
    [SerializeField] Value maxAmmo;
    public  int  currentAmmo;
    public  int ammoUsedWhenThrown;
    public int ammoUsedWhenYoyoyShot;
    bool destroyOnce;


   
    void Start()
    {
        lerpColor = GetComponent<AmmoColorLerper>();
       LightOrb = FindObjectOfType<DarkOrbDestroyer>();
       ResetAmmo();
    }

    
    void Update()
    {
        if(LightOrb.trigger.orbObject == gameObject  )
        {
            DestroyLightOrbWhenAmmoZeroThrown();
            DestroyLightOrbWhenAmmoZeroYoyoShot();
        }   
    }

   
    public  void DecreaseLightOrbAmmo(int amount)
    {
        if(currentAmmo>0)
        {
            currentAmmo -= amount;
            currentAmmo = Mathf.Clamp(currentAmmo, 0, 100);
            lerpColor.reduceColorLerpIndex(amount);
           /*  Debug.Log("Ammo" + currentAmmo); */
        }
    }
       

    void DestroyLightOrb()
    {
        if(currentAmmo<=0 &&!destroyOnce)
        {
            Destroy(gameObject);
            lightOrbsDestroyed.value++;
            destroyOnce = true;
        }
    }


    void DestroyLightOrbWhenAmmoZeroYoyoShot()
    {
        if(currentAmmo<=0 && LightOrb.IsPickedUp)
        {
            LightOrb.trigger.DropObject();
            Invoke(nameof(DestroyLightOrb),4f);
        }
    }

    void DestroyLightOrbWhenAmmoZeroThrown()
    {
        if(currentAmmo<=0 && LightOrb.IsThrown)
        {
            Invoke(nameof(DestroyLightOrb), 4f);
        }
    }

    public void ResetAmmo()
    {
        currentAmmo = maxAmmo.value;
    }

 

    
}
