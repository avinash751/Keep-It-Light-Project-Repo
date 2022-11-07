using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnObject: MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn;
    [SerializeField] float scaleOfSpawnedObject;
    [SerializeField] Vector3 positionOffsetWhenSpawned;
    private GameObject SpawnedObject;
    
    private void OnEnable()
    {
        if(SpawnedObject == null)
        {
           SpawnedObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
           OffsetSpawnedPosition();
           SetSpawnedObjectScale();
          
        }
    }
    void OffsetSpawnedPosition()
    {
        if(SpawnedObject!=null)
        {
            SpawnedObject.transform.position = transform.position + positionOffsetWhenSpawned;
        }
    }

    void SetSpawnedObjectScale()
    {
        if(SpawnedObject != null)
        {
            if(scaleOfSpawnedObject == 0)
            {
                return;
            }
            else
            {
                SpawnedObject.transform.localScale = Vector3.one * scaleOfSpawnedObject;
                OffsetSpawnedPosition();
            } 
        }      
    }

   

}
