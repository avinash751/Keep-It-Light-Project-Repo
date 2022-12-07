using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOrEnableMovingPlatforms : MonoBehaviour
{
    MovePlatform[] allPlatforms;
   PickUpObjectTrigger player;

    private void Start()
    {
        player = FindObjectOfType<PickUpObjectTrigger>();
        allPlatforms = FindObjectsOfType<MovePlatform>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player.gameObject)
        {
           EnableAllPlatforms();
           DisableAllPlatforms();
        }
    }

    void DisableAllPlatforms()
    {
        if(player.isPickedUp)
        {
            foreach(MovePlatform platform in allPlatforms)
            {
                platform.StartMoving = true;
            }
        }
    }

    void EnableAllPlatforms()
    {
        if (!player.isPickedUp)
        {
            foreach (MovePlatform platform in allPlatforms)
            {
                platform.StartMoving = false;
            }
        }
    }
}
