using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DarkOrbDestroyer : MonoBehaviour, IDestroyable
{
    [SerializeField] Value DarkOrbsDestroyed;
    PickUpObjectTrigger trigger;
    bool collided;

    public bool IsThrowable
    {
        get { return trigger.hasClicked;}
    }


    public virtual void  DestroyObject() /// destroyes the light orb 
    {
        IncrementTheNumberOfDarkOrbsDestroyed(1);
        Destroy(gameObject);
    }
    void Start()
    {
        DarkOrbsDestroyed.value = 0;
        trigger = FindObjectOfType<PickUpObjectTrigger>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<IDestroyable>() != null && collision.gameObject.GetComponent<LightOrbDestroyer>() != null)
        {
            IDestroyable destroyable = collision.gameObject.GetComponent<IDestroyable>();
            

            if (!IsThrowable && !collided)
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
