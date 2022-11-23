using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Range(0,100)][SerializeField] float jumpForce;
    [Range(0, 10)][SerializeField] float dragMultiplier;
  
    public float  JumpForce
    {
        get { return jumpForce; }

        
    }

    [SerializeField]  bool  onGround;
    public bool OnGround
    {
        get { return onGround; }
    } 

    [Range(0, 2)][SerializeField] float  GravityMultiplier;
     Rigidbody Rb;

    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        InputToJump();
        ComeDownTogroundWhenJumped();   
    }
   


    void InputToJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            onGround = false;
            JustJump();
            Rb.drag = 0;
        }
    }


    void JustJump()
    {
        Rb.velocity = Rb.velocity + (Vector3.up  * jumpForce);
    }

    void  ComeDownTogroundWhenJumped()
    {
        if ( Rb.velocity.y != 0 )
        {
            Rb.velocity +=-GravityMultiplier * Vector3.up;
          
        }
     

        if(Rb.drag!=15)
        {
            Rb.drag = Mathf.Lerp(Rb.drag, 15, Time.deltaTime * dragMultiplier);
        }
   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }
   

}
