using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehaviour : StateClass
{
    
    public RoamBehaviour Roam;
    public override StateClass DoAction()
    {
        //transform.position = Vector3.MoveTowards(transform.position, TF_Player.transform.position, speed * Time.deltaTime);
        if (distanceToPlayer < 10)
        {
            transform.rotation =
            Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(TF_Player.position - transform.position),
            rotSpeed * Time.deltaTime);

            transform.position += transform.forward * speed * Time.deltaTime;
        }
            return Roam;
        //if(distanceToPlayer > 10)
        //{
        //    return Roam;
        //}
        //else
        //{
        //    return this;
        //}
    }
}
