using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartCheckPoint : MonoBehaviour
{
    [SerializeField] Transform restartArea;

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = restartArea.position;
        }
    }
}
