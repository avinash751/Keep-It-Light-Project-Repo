using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathForEnemies : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }
}
