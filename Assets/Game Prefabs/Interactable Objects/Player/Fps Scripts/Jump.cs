using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] float JumpForce;
    [SerializeField] bool OnGround;
    [SerializeField] int JumpMultiplier;
     Rigidbody Rb;

    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        InputToJump();
    }
   


    void InputToJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && OnGround)
        {
            OnGround = false;
            JustJump();
        }
    }


    void JustJump()
    {
        Rb.velocity = (Vector3.up * JumpMultiplier * JumpForce);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            OnGround = true;
        }
    }
}
