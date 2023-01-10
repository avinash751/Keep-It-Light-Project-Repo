using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOrEnableMovingPlatforms : MonoBehaviour
{
    MovePlatform[] allPlatforms;
    PickUpObjectTrigger player;
    YoYoMechanic yoyo;
    [SerializeField]bool onlyDisable;



    private void Start()
    {
        player = FindObjectOfType<PickUpObjectTrigger>();
        allPlatforms = FindObjectsOfType<MovePlatform>();
        yoyo = FindObjectOfType<YoYoMechanic>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player.gameObject)
        {
           DisableAllPlatforms();
           EnableAllPlatforms();
        }
    }

    void EnableAllPlatforms()
    {
        if(player.isPickedUp && !onlyDisable)
        {
            foreach(MovePlatform platform in allPlatforms)
            {
                platform.StartMoving = true;
            }
        }
    }

    void DisableAllPlatforms()
    {
        if (!player.isPickedUp && onlyDisable && !yoyo.yoyoShot)
        {
            foreach (MovePlatform platform in allPlatforms)
            {
                platform.StartMoving = false;
            }
        }
    }
}
