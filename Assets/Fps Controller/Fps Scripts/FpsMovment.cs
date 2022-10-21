using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FpsMovment : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float MoveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movment();
    }

    void Movment()
    {
        float MoveX = Input.GetAxis("Horizontal");
        float MoveZ = Input.GetAxis("Vertical");
        Vector3 Direction = new Vector3 (MoveX, MoveZ, 0);
        
        rb.velocity = (transform.right * Direction.x + transform.forward * Direction.y) * MoveSpeed;

    }
}
