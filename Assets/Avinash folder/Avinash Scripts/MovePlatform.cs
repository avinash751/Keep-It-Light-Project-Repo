using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public bool StartMoving;
    public bool MoveOnX;
    public bool MoveOnY;
    public bool MoveOnZ;

    [SerializeField,Range(-5,5)] float amplitude;
    [SerializeField,Range(-5,5)] float frequency;

    [SerializeField] MeshRenderer mesh;
    [SerializeField] Color glowColor;
    [SerializeField] float desiredIntesnsity;
    [SerializeField] float intesnsity;

    private void OnValidate()
    {
       

    }

    private void Start()
    {
       
    }

    private void Update()
    {
        KeepMovingOnXaxis();
        KeepMovingOnZaxis();
        KeepMovingOnYaxis();
        LerpEmmisiveIntensity(StartMoving ? desiredIntesnsity : 0);
      
    }


    void KeepMovingOnZaxis()
    {
        if(MoveOnZ && StartMoving)
        {


            float Z = amplitude * Mathf.Sin(Time.time * frequency);
            transform.position += new Vector3(0, 0, Z);
        }
    }

    void KeepMovingOnXaxis()
    {
        if (MoveOnX && StartMoving)
        {
            float x = amplitude * Mathf.Sin(Time.time * frequency);
            transform.position += new Vector3(x, 0, 0);
        }
    }

    void KeepMovingOnYaxis()
    {
        if (MoveOnY && StartMoving)
        {
            float Y = amplitude * Mathf.Sin(Time.time * frequency);
            transform.position += new Vector3(0, Y, 0);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.parent = transform;

            if(StartMoving)
            {
                collision.gameObject.GetComponent<FpsMovment>().moveMaxSpeed = 50;
                collision.gameObject.GetComponent<FpsMovment>().moveSpeed = 20;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.parent = null;
            collision.gameObject.GetComponent<FpsMovment>().moveMaxSpeed = 15;
            collision.gameObject.GetComponent<FpsMovment>().moveSpeed = 6;
        }
    }


    void LerpEmmisiveIntensity(float EndValue)
    {
        intesnsity = Mathf.Lerp(intesnsity, EndValue,1.5f * Time.deltaTime);
        mesh.material.SetColor("_EmissionColor", glowColor * intesnsity);
    }

}
