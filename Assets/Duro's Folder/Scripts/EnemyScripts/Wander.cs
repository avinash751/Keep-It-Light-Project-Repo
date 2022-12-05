using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    Rigidbody rb;
    public Transform TF_Player;

    [SerializeField] float speed = 5f;
    [SerializeField] Vector3 SetDirectionToMove;
    [SerializeField] float maxSpeed;
    bool chasing;


    float distanceToPlayer; 



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating(nameof(AfterCertainTimeChangeDirection), 3, 3);
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

        if (distanceToPlayer <= 10)
        {
            Debug.Log("close to player");
            ChasePlayer();
        }
        else
        {
            WanderToDirection();
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
    }
}
