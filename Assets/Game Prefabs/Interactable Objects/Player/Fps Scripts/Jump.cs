using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Jump : MonoBehaviour
{
    
    
    [SerializeField] bool StartGravity;
    [SerializeField] bool onGround;

    [Range(0, 100)][SerializeField] float jumpForce;
    [Range(0, 1)][SerializeField] float gravityTimer;
    [Range(0, 30)][SerializeField] float MomentumMultiplier;
    [Range(0, 5)][SerializeField] float GravityMultiplier;

    [SerializeField] AudioSource jumpSound;
    [SerializeField] Transform CamPlaceHolder;

    FpsMovment move;
    Rigidbody Rb;

    public float  JumpForce
    {
        get { return jumpForce; }
    }
    public bool OnGround
    {
        get { return onGround; }
    } 

   
    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        InputToJump();
        GravityWhenNotOnGroundAndJumping();
        GravityOnGround();
    }
  
    void InputToJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            onGround = false;
            JustJump();
            Invoke(nameof(EnableGravity), gravityTimer);
            resetingDragSpeed(0);
        }
    }

    void JustJump()
    {
        Rb.velocity = new Vector3(Rb.velocity.x, 0, Rb.velocity.z);
        JumpWithMomentumWhenVelocityIsGreater();
        JumpWithNoMomentumWhenVelocityIsLess();
          
    }

    void JumpWithMomentumWhenVelocityIsGreater()
    {
        if(Rb.velocity.magnitude >1)
        {
            Rb.velocity += (Vector3.up * jumpForce) + CamPlaceHolder.forward * MomentumMultiplier;
        }
    }

    void JumpWithNoMomentumWhenVelocityIsLess()
    {
        if (Rb.velocity.magnitude < 1)
        {
            Rb.velocity += (Vector3.up * jumpForce);
        }
    }


    void  GravityWhenNotOnGroundAndJumping()
    {
        if ( Rb.velocity.y !=0 && StartGravity)
        {
            Rb.velocity +=-GravityMultiplier * Vector3.up *50 * Time.deltaTime;
        }
        if(onGround)
        {
            StartGravity = false;
        }
    }

    void EnableGravity()
    {
        StartGravity = true;
    }

    void resetingDragSpeed(float amount)
    {
        Rb.drag = amount;
    }

    void GravityOnGround()
    {
        if(onGround && Rb.velocity.y<-0.1f)
        {
            Rb.velocity -= Vector3.up * 300f * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            WhenBackOnGround();
        }
    }

    void WhenBackOnGround()
    {
        if (!OnGround)
        {
            onGround = true;
            resetingDragSpeed(10);
            jumpSound.pitch = Random.Range(1.3f, 1.8f);
            jumpSound.Play();
        }
    }
   

}
