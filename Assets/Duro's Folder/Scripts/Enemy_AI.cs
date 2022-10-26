using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{

    Transform TF_Player;
    float RotationSpeed = 3.0f;
    float MoveSpeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        TF_Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update() //look and then move to direction of player
    {
        transform.rotation =
            Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(TF_Player.position - transform.position), 
            RotationSpeed * Time.deltaTime);

        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
    }
}
