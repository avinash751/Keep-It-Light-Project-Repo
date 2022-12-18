using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAndEnableYPlatforms : MonoBehaviour
{
    PickUpObjectTrigger orb;
    // Start is called before the first frame update
    void Start()
    {
        orb = FindObjectOfType<PickUpObjectTrigger>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if(!orb.isPickedUp)
        {
            DisableYaxisPlatfroms(other.gameObject);
        }
    }

    void DisableYaxisPlatfroms(GameObject gameObject)
    {
        if(gameObject.TryGetComponent(out PlatformTag platform))
        {
            platform.gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
}
