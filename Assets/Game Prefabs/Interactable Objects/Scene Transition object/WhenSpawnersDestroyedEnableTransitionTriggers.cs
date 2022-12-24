using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenSpawnersDestroyedEnableTransitionTriggers : MonoBehaviour
{
    [SerializeField] List<GameObject> SpawnerList;
 



    void Update()
    {
        EnableTriggerWhenSpawnerNull();

    }


    bool CheckIfAllSpawnersOurNull()
    {
        for (int i = 0; i < SpawnerList.Count; i++)
        {
            if (SpawnerList[i] == null)
            {
                SpawnerList.RemoveAt(i);
            }
        }
        if (SpawnerList.Count==0) { return true; }
        else { return false; }
    }
    void EnableTriggerWhenSpawnerNull()
    {
        if (CheckIfAllSpawnersOurNull())
        {
            Debug.Log("all spawners killed");
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
