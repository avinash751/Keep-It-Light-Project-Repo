using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{

    Transform TF_Path;
    Transform TF_Player;
    //float RotationSpeed = 3.0f;
    [SerializeField] float MoveSpeed = 7f;
    float rotSpeed = 100f;
    bool close;
    float dist;

    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotateRight = false;
    private bool isWalking = false;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        TF_Player = UnityEngine.GameObject.FindGameObjectWithTag("Player").transform;
        TF_Path = UnityEngine.GameObject.FindGameObjectWithTag("Path").transform;
        rb = GetComponent<Rigidbody>();
    }



    // Update is called once per frame
    void Update() //look and then move to direction of player
    {

        //Vector3 Randomdirection = Random.insideUnitSphere * 4;
        //Randomdirection += transform.position;
        //rb.velocity = Vector3.MoveTowards(transform.position, Randomdirection, 10 * Time.deltaTime);
        dist = Vector3.Distance(transform.position, TF_Player.transform.position);
        


        if (isWandering == false)
        {
            StartCoroutine(Wander());
        }
        
        if (isRotateRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
        }
        if (isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
        }
        if(isWalking == true)
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }

        //.velocity = Vector3.ClampMagnitude(rb.velocity, MoveSpeed);

        /*
        if (dist < 5)
        {
            
        }
       
        else if (dist > 7)
        {
            close = false;
            StartCoroutine(Wander());
            // GetComponent<Flee>().enabled = false;
        }
        
        if (!close)
        {
            transform.rotation =
            Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(TF_Player.position - transform.position),
            rotSpeed * Time.deltaTime);

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;        }
        else
        {
            //GetComponent<Flee>().enabled = true;
        }
        */



        //float targetRange = 20f;
        //if (dist <= targetRange)
        //{

        //    transform.rotation =
        //            Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(TF_Player.position - transform.position),
        //            rotSpeed * Time.deltaTime);

        //    rb.velocity += transform.forward * MoveSpeed * Time.deltaTime;
        //}
        //else
        //{
        //    transform.rotation =
        //            Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(TF_Path.position - transform.position),
        //            rotSpeed * Time.deltaTime);

        //    transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        //}
        

    }

    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 4);
        int rotateLeftorRight = Random.Range(0, 3);
        int walkWait = Random.Range(1, 4);
        int walkTime = Random.Range(1, 5);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);
        if (rotateLeftorRight == 1)
        {
            isRotateRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotateRight = false;
        }
        if (rotateLeftorRight == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotateRight = false;
        }
        isWandering = false;

    }

}
