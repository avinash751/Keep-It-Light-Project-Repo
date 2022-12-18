using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{

    bool isFalling = false;
    float downSpeed = 0;
    [SerializeField] float fallSpeed;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name == "Player Fps")
        {
            isFalling = true;
            Destroy(gameObject, 5);
        }
    }

    void Update()
    {
        if(isFalling)
        {
            downSpeed += Time.deltaTime/fallSpeed;
            transform.position = new Vector3(transform.position.x, transform.position.y - downSpeed, transform.position.z);
        }
    }
}
