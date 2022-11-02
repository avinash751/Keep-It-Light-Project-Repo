using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Jump))]
public class FpsMovment : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] Transform cameraPostionHolderDirection;
    [Range(0,30)][SerializeField] float moveMaxSpeed;
    [Range(0,30)][SerializeField] float moveSpeed;
    [Range(0, 2)][SerializeField] float slowDownMultiplier;
    [Range(0, 30)][SerializeField] float SpeedToStartSlwoingDown;
    
    Jump Jump;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       Jump= GetComponent<Jump>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movment();
    }

    void Movment()
    {
        var normalisedDirection = GetHorizontalAndVerticalDirectionForMoving();
        rb.velocity += (cameraPostionHolderDirection.right * normalisedDirection.x + cameraPostionHolderDirection.forward * normalisedDirection.z) * moveSpeed ;

        TruncateVelocity(rb.velocity.magnitude > moveMaxSpeed ? moveMaxSpeed : rb.velocity.magnitude);
        ReduceVeclocityGraduallyWhenACertainSpeedIsMet(SpeedToStartSlwoingDown);

    }

    Vector3 GetHorizontalAndVerticalDirectionForMoving()
    {
        float MoveX = Input.GetAxisRaw("Horizontal");
        float MoveZ = Input.GetAxisRaw("Vertical");
        Vector3 Direction = new Vector3(MoveX, rb.velocity.y, MoveZ);
        Direction.Normalize();

        return Direction;
    }
    void TruncateVelocity(float maxSpeed)
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }

    void ReduceVeclocityGraduallyWhenACertainSpeedIsMet(float SpeedrequiredToStartSlowingDown)
    {
        if(rb.velocity.magnitude<= SpeedrequiredToStartSlowingDown)
        {
            if(Jump.OnGround && rb.velocity.y<=0 && rb.velocity.y>-0.8f)
            {
                rb.velocity *= slowDownMultiplier;
                Debug.Log("reducing speed;");
            }
        }
    }
}
