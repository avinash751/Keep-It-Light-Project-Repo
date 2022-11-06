using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LightOrbDestroyer : MonoBehaviour,IDestroyable
{
    [SerializeField] Value LightOrbsDestroyed;
   
   
    // Start is called before the first frame update

    private void Start()
    {
        LightOrbsDestroyed.value = 0;
        
    }

   
    
   
    public virtual void DestroyObject() /// destroyes the dark spawner 
    {
        IncrementTheNumberOfLightOrbsDestroyed(1);
        Destroy(gameObject.transform.parent.gameObject);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<IDestroyable>()!=null && collision.gameObject.GetComponent<DarkOrbDestroyer>()!=null)
        {
            IDestroyable destroyable = collision.gameObject.GetComponent<IDestroyable>();
            DarkOrbDestroyer lightOrb = destroyable as DarkOrbDestroyer;

            if(!lightOrb.IsThrowable )
            {
               
                 destroyable.DestroyObject();
            }
        }
    }

    void IncrementTheNumberOfLightOrbsDestroyed(int amount)
    {
        LightOrbsDestroyed.value += amount;
    }
}
