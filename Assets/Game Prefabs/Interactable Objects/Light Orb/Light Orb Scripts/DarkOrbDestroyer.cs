using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DarkOrbDestroyer : MonoBehaviour, IDestroyable
{
   [SerializeField] Value DarkOrbsDestroyed;
    PickUpObjectTrigger trigger;
    YoYoMechanic YoYo;
    LightOrbAmmoCountSystem orbAmmo;
    bool collided;

    public bool IsPickedUp
    {
        get { return trigger.isPickedUp;}
    }

    public bool YoyoShot
    {
        get { return YoYo.yoyoShot;}
    }


    public virtual void  DestroyObject() /// destroyes the light orb 
    {
        IncrementTheNumberOfDarkOrbsDestroyed(1);
        orbAmmo.AmmoText.SetActive(false);
        Destroy(gameObject);
    }
    void Start()
    {

        orbAmmo = FindObjectOfType<LightOrbAmmoCountSystem>();
        trigger = FindObjectOfType<PickUpObjectTrigger>();
        YoYo = FindObjectOfType<YoYoMechanic>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<IDestroyable>() != null && collision.gameObject.GetComponent<LightOrbDestroyer>() != null)
        {
            IDestroyable destroyable = collision.gameObject.GetComponent<IDestroyable>();
            

            if (!IsPickedUp && !collided && !YoyoShot)
            {
                collided = true;
                destroyable.DestroyObject();
            }
        }
    }

    void IncrementTheNumberOfDarkOrbsDestroyed(int amount)
    {
        DarkOrbsDestroyed.value += amount;
    }

 


}
