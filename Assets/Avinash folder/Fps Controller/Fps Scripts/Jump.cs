using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] float JumpForce;
    [SerializeField] float gravityForce;
    [SerializeField] bool OnGround;
    [SerializeField] float MinPositionToFallDown;
    [SerializeField] float DurationOfFall;
    float time;
     Rigidbody Rb;

    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        OnGround = true;
    }

    void Update()
    {
        JustJump();
        BringPlayerDownWhenUp();
        
    }

    void JustJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && OnGround)
        {
            OnGround = false;
            Rb.AddForce(Vector3.up * JumpForce *1000);
        }
    }


    void BringPlayerDownWhenUp()
    {
        float Yposition = gameObject.transform.position.y;
        if (Yposition >MinPositionToFallDown && Yposition !=1)
        {
            time += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(Yposition, 1, time / DurationOfFall),transform.position.z);
        }
        else
        {
            time = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            OnGround = true;
        }
    }
}
