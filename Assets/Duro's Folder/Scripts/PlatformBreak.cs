using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBreak : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Light Orb"))
        {
            Destroy(collision.gameObject);
        }
       
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.CompareTag("Ground"))
    //    {
    //        Destroy(other.gameObject);
    //    }
    //}
}
