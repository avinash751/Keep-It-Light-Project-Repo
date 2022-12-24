using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePlatformsThatAreInTrigger : MonoBehaviour
{
    PickUpObjectTrigger orbPickUp;
    [SerializeField] float triggerscale;

    private void OnValidate()
    {
        gameObject.GetComponent<BoxCollider>().size = new Vector3(triggerscale, triggerscale, triggerscale);
    }

    private void Start()
    {
        orbPickUp = FindObjectOfType<PickUpObjectTrigger>();
      
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.TryGetComponent( out MovePlatform platform ) && orbPickUp.isPickedUp && !platform.StartMoving)
        {
            platform.StartMoving = true;

        }

      
    }
}
