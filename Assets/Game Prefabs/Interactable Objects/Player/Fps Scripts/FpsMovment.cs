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
    [Range(0,30)][SerializeField] public float moveMaxSpeed;
    [Range(0,30)][SerializeField] float moveSpeed;
    [Range(0, 10)][SerializeField] float slowDownTime;
    [SerializeField] AudioSource walkingSound;
    Jump Jump;
    bool walking;




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
        PlayWalkingSound();
    }

    void Movment()
    {
        var normalisedDirection = GetHorizontalAndVerticalDirectionForMoving();
        rb.velocity += (cameraPostionHolderDirection.right * normalisedDirection.x + cameraPostionHolderDirection.forward * normalisedDirection.z) * moveSpeed ;
        

        TruncateVelocity(rb.velocity.magnitude > moveMaxSpeed && Jump.OnGround ? moveMaxSpeed : rb.velocity.magnitude);
        TruncateVelocityWhenNotOnGround(moveMaxSpeed);
        SlowDown();

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

    void TruncateVelocityWhenNotOnGround(float maxSpeed)
    {
        if (!Jump.OnGround)
        {
            rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -maxSpeed / 1.3f, maxSpeed / 1.3f), rb.velocity.y, Mathf.Clamp(rb.velocity.z, -maxSpeed / 1.3f, maxSpeed / 1.3f));
        }
    }


    void SlowDown()
    {
        rb.velocity = Vector3.Lerp(rb.velocity,Vector3.zero, Time.deltaTime * slowDownTime);
    }

    void PlayWalkingSound()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) && Jump.OnGround)
        {
            
            walkingSound.enabled = true;
        }
        else if(!Input.GetKey(KeyCode.W) || !Input.GetKey(KeyCode.A) || !Input.GetKey(KeyCode.S) || !Input.GetKey(KeyCode.D))
        {
            walkingSound.enabled = false;
            walkingSound.pitch = Random.Range(0.7f, 1.1f);
        }

        if(!Jump.OnGround)
        {
            walkingSound.enabled = false;
        }
    }

   
}
