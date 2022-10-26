using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FpsMovment : MonoBehaviour
{
    Rigidbody rb;
    [Range(0,20)][SerializeField] float MoveSpeed;
    [Range(0, 20)][SerializeField] float SmoothTime;
    [Range(0, 20)][SerializeField] float SmoothMaxSpeed;
    private Vector3 RefVelocity = Vector3.zero;
    private Vector3 currentDir = Vector3.zero;
    private float startTime;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startTime = Time.time;  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movment();
    }

    void Movment()
    {
        float MoveX = Input.GetAxisRaw("Horizontal");
        float MoveZ = Input.GetAxisRaw("Vertical");
        Vector3 Direction = new Vector3 (MoveX, MoveZ, 0);
        Direction.Normalize();

       
        
        rb.velocity = (transform.right * Direction.x + transform.forward * Direction.y) * MoveSpeed;

        // Vector3.SmoothDamp(currentDir, Direction, ref RefVelocity, SmoothTime,SmoothMaxSpeed);
       // currentDir = Vector3.Lerp(currentDir, Direction, Mathf.SmoothStep(0, 1, Time.time - startTime / SmoothTime));





    }
}
