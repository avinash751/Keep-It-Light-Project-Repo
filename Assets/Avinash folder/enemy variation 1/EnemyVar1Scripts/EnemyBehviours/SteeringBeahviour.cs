using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBeahviour : MonoBehaviour
{
    [SerializeField] float maxSpeed;
    [SerializeField] float steeringSpeed;
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform player;



    private void Start()
    {
        rb =GetComponent<Rigidbody>();
        player = FindObjectOfType<FpsMovment>().gameObject.transform;
    }


    Vector3 FindTargetDirection(Transform target)
    {
        var targetDirection = target.position-transform.position;
        var normalisedDirection = targetDirection.normalized;
        return normalisedDirection ;
    }

    Vector3 FleeingFromTarget(Transform target)
    {
        var targetDirection = transform.position - target.position;
        var normalisedDirection = targetDirection.normalized;
        return normalisedDirection;
    }

    void MoveToDestination(Transform target)
    {
        Vector3 targetDirection = FindTargetDirection(target);
        rb.velocity += targetDirection * steeringSpeed;
        TruncateVelocity(maxSpeed);     
    }

    void RotateAroundTarget(Transform target)
    {
        transform.RotateAround(target.position * 5, Vector3.up, 45 * Time.deltaTime);
    }

    void TruncateVelocity(float maxSpeedToClamp)
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeedToClamp);
    }



}
