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
    Vector3 startPosition;
    float elapsedTime;
    [SerializeField] float durationToLerpToOrgin;
    bool allowedToMove;



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
       startPosition = transform.position;
    }

    private void Update()
    {
       
        MovePlatformInAnyOfTheThreeDirections();
        LerpEmmisiveIntensity(StartMoving ? desiredIntesnsity : 0);
        MoveBackToOrginWhenPlatformsDeactivated();

        if(!StartMoving)
        {
            allowedToMove = false;
        }
    }

    void MovePlatformInAnyOfTheThreeDirections()
    {
        if (elapsedTime==0 && StartMoving && allowedToMove)
        {
            KeepMovingOnXaxis();
            KeepMovingOnZaxis();
            KeepMovingOnYaxis();
        } 
    }

    void MoveBackToOrginWhenPlatformsDeactivated()
    {
        (bool shouldPlatformMoveToOrgin,
         bool positionIsOnOrgin,
         bool isTimeUpToStopLerping) = CheckWhetherPlatformHasToMoveBackToOrgin();

        if(shouldPlatformMoveToOrgin)
        {
            LerpPlatformToOrginAndUpdateElapsedTime();
        }
        else
        {
            allowedToMove = true;
        }

        ResetPlatformPositionToOrgiAndElapsedTimeWhenTimeIsUp(positionIsOnOrgin,allowedToMove); 
    }

    void ResetPlatformPositionToOrgiAndElapsedTimeWhenTimeIsUp(bool condition1, bool condition2)
    {
        if (condition1 && condition2)
        {
            elapsedTime = 0;
            transform.position = startPosition;
        }
    }

    (bool, bool, bool)  CheckWhetherPlatformHasToMoveBackToOrgin()
    {
        bool positionIsOnOrgin = transform.position == startPosition;
        bool isTimeUpToStopLerping = elapsedTime >= durationToLerpToOrgin;

        if (!allowedToMove &&!positionIsOnOrgin && !isTimeUpToStopLerping)
        {
            return (true,positionIsOnOrgin,isTimeUpToStopLerping);
        }
        return (false,positionIsOnOrgin,isTimeUpToStopLerping);
    }

    void LerpPlatformToOrginAndUpdateElapsedTime()
    {
        elapsedTime += Time.deltaTime;
        var t = elapsedTime/durationToLerpToOrgin;
        transform.position = Vector3.Lerp(transform.position, startPosition, elapsedTime);
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
                collision.gameObject.GetComponent<FpsMovment>().moveMaxSpeed = 25;
                collision.gameObject.GetComponent<FpsMovment>().moveSpeed = 10;
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
