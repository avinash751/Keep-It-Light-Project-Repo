using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolve: MonoBehaviour
{
    [SerializeField] Rigidbody body;
    public Transform targetToRevolveAround;
    [SerializeField] float rotationSpeed;
    [SerializeField] float moveFrequency;
    [SerializeField] float moveAmplitude;
    [SerializeField] float moveRadius;
    void Start()
    {
        InvokeRepeating(nameof(ChangeSpeedOverTime), 2, 2);
       body = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        RotateAroundDarkOrb();
    }


   
    void RotateAroundDarkOrb()
    {
        transform.RotateAround(targetToRevolveAround.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }

    void ChangeSpeedOverTime()
    {
        rotationSpeed = Random.Range(100,200);
    }
}
