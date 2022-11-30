using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Range(0,100)][SerializeField] float jumpForce;
    FpsMovment move;
    [SerializeField] bool StartGravity;
    [Range(0, 1)][SerializeField] float gravityTimer;

    public float  JumpForce
    {
        get { return jumpForce; }
    }

    [SerializeField]  bool  onGround;
    public bool OnGround
    {
        get { return onGround; }
    } 

    [Range(0, 5)][SerializeField] float  GravityMultiplier;
     Rigidbody Rb;

    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        InputToJump();
        ComeDownTogroundWhenJumped();
        GravityOnGround();
    }
  
    void InputToJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            onGround = false;
            JustJump();
            resetingDragSpeed(0);
            Invoke(nameof(EnableGravity), gravityTimer); 
        }
    }

    void resetingDragSpeed(float amount)
    {
        Rb.drag = amount;
   
    }


    void JustJump()
    {
      
        Rb.velocity +=   (Vector3.up  * jumpForce);
    }

    void  ComeDownTogroundWhenJumped()
    {
        if ( Rb.velocity.y !=0 && StartGravity)
        {
            Rb.velocity +=-GravityMultiplier * Vector3.up;
          
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

    void GravityOnGround()
    {
        if(onGround && Rb.velocity.y<-0.1f)
        {
            Rb.velocity -= Vector3.up * 3.5f;
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            onGround = true;
            resetingDragSpeed(10);
        }
    }
   

}
