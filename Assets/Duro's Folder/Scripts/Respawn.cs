using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //player.transform.position = respawnPoint.transform.position;
            other.gameObject.transform.position = respawnPoint.position;
        }
        if(other.TryGetComponent(out DarkOrbDestroyer lightorb) )
        {
            lightorb.DestroyObject();
        }
    }
}
