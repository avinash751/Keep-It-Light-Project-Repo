using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DarkOrbDestroyer : MonoBehaviour, IDestroyable
{
   [SerializeField] Value DarkOrbsDestroyed;
    [HideInInspector]
    public PickUpObjectTrigger trigger;
    [HideInInspector]
    public YoYoMechanic YoYo;
    [HideInInspector]
    public ThrowObject throwOrb;
    bool collided;
    public AudioSource OrbEquipSound;

    public bool IsPickedUp
    {
        get { return trigger.isPickedUp;}
    }

    public bool YoyoShot
    {
        get { return YoYo.yoyoShot;}
    }

    public bool IsThrown
    {
        get { return throwOrb.throwObject;}
    }

    private void Awake()
    {
        throwOrb = FindObjectOfType<ThrowObject>();
        trigger = FindObjectOfType<PickUpObjectTrigger>();
        YoYo = FindObjectOfType<YoYoMechanic>();
    }

    public virtual void  DestroyObject() /// destroyes the light orb 
    {
        Destroy(gameObject);
    }
    void Start()
    {

      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<IDestroyable>() != null && collision.gameObject.GetComponent<LightOrbDestroyer>() != null)
        {
            IDestroyable destroyable = collision.gameObject.GetComponent<IDestroyable>();
           
            if (!IsPickedUp && !collided && !YoyoShot)
            {
                IncrementTheNumberOfDarkOrbsDestroyed(1);
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
