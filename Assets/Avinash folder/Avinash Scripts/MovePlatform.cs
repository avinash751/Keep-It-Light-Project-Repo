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

    private void OnValidate()
    {
        if(MoveOnX)
        {
            MoveOnZ = false;
        }
        else if(MoveOnZ)
        {
            MoveOnX = false;
        }

    }

    private void Update()
    {
        KeepMovingOnXaxis();
        KeepMovingOnZaxis();
        KeepMovingOnYaxis();
    }


    void KeepMovingOnZaxis()
    {
        if(MoveOnZ && StartMoving)
        {
            float Z =  amplitude*Mathf.Sin(Time.time * frequency);
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

}
