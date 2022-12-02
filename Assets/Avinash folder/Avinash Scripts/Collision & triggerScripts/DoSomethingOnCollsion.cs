using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class DoSomethingOnCollsion : MonoBehaviour
{
    [SerializeField] string CollsionTag;
    public UnityEvent doSomethingOnCollsion;
    Rigidbody rb;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == CollsionTag)
        {
         doSomethingOnCollsion.Invoke();
            
        }
    }
}
