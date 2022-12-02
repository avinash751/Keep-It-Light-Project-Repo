using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 5f;
    [SerializeField] Vector3 SetDirectionToMove;
    [SerializeField] float maxSpeed;



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
        WanderToDirection();
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
}
