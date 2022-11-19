using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    float dist;
    [SerializeField] Value currentPanic;
    [SerializeField] Value maxPanic;
    bool adding;


    Transform TF_Player;
    [ Header("Enemy Movment Settings")]
    [SerializeField]public  float RotationSpeed  = 3.0f;
    [SerializeField]public float MoveSpeed  = 3.0f;

    [Header("Enemy Obstacle avoidance seettings")]
    public float targetVelocity = 10.0f;
    public int numberOfRays = 19;
    public float angle = 90;
    public float rayRange = 2f;

    // Start is called before the first frame update
    void Start()
    {
        TF_Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update() //look and then move to direction of player
    {

        var deltaPosition = Vector3.zero;

        transform.rotation =
            Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(TF_Player.position - transform.position),
            RotationSpeed * Time.deltaTime);

        transform.position += transform.forward * MoveSpeed * Time.deltaTime;


        for (int i = 0; i < numberOfRays; i++)
        {
            var rotation = this.transform.rotation;
            var rotationModifier = Quaternion.AngleAxis(i / (float)numberOfRays * angle * 2 - angle, this.transform.up);
            var direction = rotation * rotationModifier * Vector3.forward;


            RaycastHit hitInfo;
            var ray = new Ray(this.transform.position, direction);
            if (Physics.Raycast(ray, out hitInfo, rayRange))
            {
                deltaPosition -= (3.0f / numberOfRays) * targetVelocity * direction;
            }
            else
            {
                deltaPosition += (3.0f / numberOfRays) * targetVelocity * direction;
            }
        }
        this.transform.position += deltaPosition * Time.deltaTime;

        dist = Vector3.Distance(transform.position, TF_Player.transform.position);
        if(dist < 5 &&!adding)
        {
            currentPanic.value += 2;
            adding = true;
            Debug.Log("adding");
        }
        else if(dist > 5 && adding)
        {
            currentPanic.value -= 1;
            adding = false;
        }
    }


    
    void OnDrawGizmos()
    {
        for (int i = 0; i < numberOfRays; i++)
        {
            var rotation = this.transform.rotation;
            var rotationModifier = Quaternion.AngleAxis(i / ((float)numberOfRays - 1) * angle * 2 - angle, this.transform.up);
            var direction = rotation * rotationModifier * Vector3.forward;
            Gizmos.DrawRay(this.transform.position, direction);
        }
    }
   

}
