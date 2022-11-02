using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Range(0,100)][SerializeField] float jumpForce;
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
        }
    }


    void JustJump()
    {
        Rb.velocity = (Vector3.up  * jumpForce);
    }

    void  ComeDownTogroundWhenJumped()
    {
        if( Rb.velocity.y!=0)
        {
            Rb.velocity += -transform.up * GravityMultiplier;
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
