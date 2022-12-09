using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateClass : MonoBehaviour
{
    public Rigidbody rb;
    public Transform TF_Player;

    [SerializeField] public float speed = 10f;
    [SerializeField] public Vector3 SetDirectionToMove;
    [SerializeField] public float maxSpeed;
    public bool chasing;

    public float rotSpeed = 50f;


    public float distanceToPlayer;


    public abstract StateClass DoAction();
}
