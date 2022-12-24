using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DarkOrbDestroyer : MonoBehaviour, IDestroyable
{
   [SerializeField] Value DarkOrbsDestroyed;
    [SerializeField] Value lightOrbDestroyed;
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
        lightOrbDestroyed.value++;
    }
    void Start()
    {

      
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDestroyable destroyable = collision.gameObject.GetComponent<LightOrbDestroyer>();
        if (destroyable != null)
        {
            
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
