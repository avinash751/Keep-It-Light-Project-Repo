using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    Rigidbody rb;
    Transform TF_Player;

    [SerializeField] float speed = 10f;
    [SerializeField] Vector3 SetDirectionToMove;
    [SerializeField] float maxSpeed;
    [SerializeField] float playerChaseRange;
    [SerializeField] GameObject particleSystem;
    bool chasing;

    float rotSpeed = 50f;


    float distanceToPlayer; 



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating(nameof(AfterCertainTimeChangeDirection), 3, 3);
        TF_Player = FindObjectOfType<FpsMovment>().transform;
    }
    Vector3 SetRandomDir(float maxRangeX, float maxRangeZ)
    {
        Vector3 RandomDirection = new Vector3(Random.Range(-maxRangeX, maxRangeX), 0, Random.Range(-maxRangeZ, maxRangeZ));
        return RandomDirection;
    }

    void WanderToDirection()
    {
        rb.velocity = SetDirectionToMove * speed * Time.deltaTime;
        TruncateVelocity();
    }
    private void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, TF_Player.transform.position);

        if (distanceToPlayer <= playerChaseRange)
        {
            Debug.Log("close to player");
            ChasePlayer();
            if (particleSystem != null) { particleSystem.SetActive(true); }
        }
        else
        {
            WanderToDirection();
            if(particleSystem != null) { particleSystem.SetActive(false); }
            
        }
    }

    void AfterCertainTimeChangeDirection()
    {      
        SetDirectionToMove = SetRandomDir(100, 100);
        Debug.Log("Direction has been changed");      
    }
    void TruncateVelocity()
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity,maxSpeed);
    }

    void ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, TF_Player.transform.position, speed * Time.deltaTime);
        if(distanceToPlayer < playerChaseRange)
        {
            transform.rotation =
            Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(TF_Player.position - transform.position),
            rotSpeed * Time.deltaTime);

            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
