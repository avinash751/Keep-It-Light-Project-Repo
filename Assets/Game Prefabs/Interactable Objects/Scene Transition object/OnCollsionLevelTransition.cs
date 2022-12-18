using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnCollsionLevelTransition : MonoBehaviour
{
    [SerializeField] int SceneToTransition;
    [SerializeField] bool isTrigger;

    private void OnValidate()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    { 
        if (isTrigger) {return;}

        else if (collision.gameObject.TryGetComponent(out FpsMovment player))
        {
            SceneManager.LoadScene(SceneToTransition);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!isTrigger) {return;}

        else if (other.gameObject.TryGetComponent(out FpsMovment player))
        {
            SceneManager.LoadScene(SceneToTransition);
        }
    }
}