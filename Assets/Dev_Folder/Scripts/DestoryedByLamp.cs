using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryedByLamp : MonoBehaviour
{
    bool hitByLamp;
    void Update()
    {
        if(hitByLamp)
        {
            Destroy(this);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Lamp")
        {
            hitByLamp = true;
        }
    }
}
