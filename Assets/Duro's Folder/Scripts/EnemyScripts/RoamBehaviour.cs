using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamBehaviour : StateClass
{
    public ChaseBehaviour Chase;
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

    void AfterCertainTimeChangeDirection()
    {
        SetDirectionToMove = SetRandomDir(100, 100);
        Debug.Log("Direction has been changed");
    }
    void TruncateVelocity()
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }
    public override StateClass DoAction()
    {
        distanceToPlayer = Vector3.Distance(transform.position, TF_Player.transform.position);

        if (distanceToPlayer < 5)
        {
            Debug.Log("close to player");
            return Chase;
        }
        else if(distanceToPlayer > 5)
        {
            WanderToDirection();
        }
            return this;
    }

}
