using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderAI : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotSpeed = 100f;

    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotateRight = false;
    private bool isWalking = false;

    Transform TF_Path;
    Transform TF_Player;

    float dist;

    Rigidbody rb;


    //float dist = Vector3.Distance(transform.position, TF_Player.transform.position);

    // Start is called before the first frame update
    void Start()
    {
        TF_Player = GameObject.FindGameObjectWithTag("Player").transform;
        TF_Path = GameObject.FindGameObjectWithTag("Path").transform;
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
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
        if (isWalking == true)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 2);
        int rotateWait = Random.Range(1, 3);
        int rotateLeftorRight = Random.Range(1, 2);
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
            isRotatingLeft = false;
        }
        if (rotateLeftorRight == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotateRight = false;
        }
        isWandering = false;

    }
    public void ChasePlayer()
    {
        if (dist < 3)
        {
            StopAllCoroutines();
            transform.rotation =
            Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(TF_Player.position - transform.position),
            rotSpeed * Time.deltaTime);

            rb.velocity += transform.forward * moveSpeed * Time.deltaTime;
        }
        if (dist >= 4)
        {
            StartCoroutine(Wander());
        }
    }
}
