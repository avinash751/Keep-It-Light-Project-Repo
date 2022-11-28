using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{

    Transform TF_Path;
    Transform TF_Player;
    float RotationSpeed = 3.0f;
    float MoveSpeed = 3.0f;
    bool close;
    float dist;


    // Start is called before the first frame update
    void Start()
    {
        TF_Player = GameObject.FindGameObjectWithTag("Player").transform;
        TF_Path = GameObject.FindGameObjectWithTag("Path").transform;
    }



    // Update is called once per frame
    void Update() //look and then move to direction of player
    {
        Vector3 Randomdirection = Random.insideUnitSphere * 4;
        Randomdirection += transform.position;
        transform.position = Vector3.MoveTowards(transform.position, Randomdirection, 3 * Time.deltaTime);
        dist = Vector3.Distance(transform.position, TF_Player.transform.position);

        if (dist < 50)
        {
            close = true;
        }
        else if (dist > 70)
        {
            close = false;
           // GetComponent<Flee>().enabled = false;
        }
        if (!close)
        {
            transform.rotation =
            Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(TF_Player.position - transform.position),
            RotationSpeed * Time.deltaTime);

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
        else
        {
            //GetComponent<Flee>().enabled = true;
        }
        float targetRange = 20f;
        if (dist <= targetRange)
        {
            transform.rotation =
                    Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(TF_Player.position - transform.position),
                    RotationSpeed * Time.deltaTime);

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
        else
        {
            transform.rotation =
                    Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(TF_Path.position - transform.position),
                    RotationSpeed * Time.deltaTime);

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
    }

}
