
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject LightOrbPrefabTpSpawn;
    [SerializeField] LightOrbsInspector lightOrbsSpawnData; // this a detaield view of how many light orbs present and its location and function to chnage its values 
    [SerializeField] int LightOrbsDestroyedToStartSpawnning;
    [SerializeField] int AmountOfLightOrbsToSpawn;
    [SerializeField] int maxDelayTimeToSpawn;
    [SerializeField] bool StartSpawning;
    [SerializeField] bool NewLightOrbsSpawned;
    private int OrbsSpawned;


  
    private void Start()
    {
        lightOrbsSpawnData.availableSpawnLocationsOfLightOrbs.Clear();
       
    }
    void Update()
    {
        AmountOfLightOrbsRequiredToStartSpawning(LightOrbsDestroyedToStartSpawnning);
        StartLightOrbSpawningProcess();
        ResetTheNumberOfLightOrbsDestroyed();
        
    }

    void AmountOfLightOrbsRequiredToStartSpawning(float amount)
    {
        int lightOrbsDestroyed = lightOrbsSpawnData.lightOrbsdestroyed.value;

        if(lightOrbsDestroyed == amount)
        {
            StartSpawning = true;
        }
    }

    void StartLightOrbSpawningProcess()
    {
        if(StartSpawning)
        {
            NewLightOrbsSpawned = false;
            SpawnOrb();
            SetNumberOfOrbsRequiredToBeDestroyedToStartSpawn(OrbsSpawned);
        }
    }
    void SpawnOrb()
    {
        OrbsSpawned = 0;
        List<Vector3> AllAvailableLightOrbSpawnLocations = lightOrbsSpawnData.availableSpawnLocationsOfLightOrbs;
        int[] SelectedLocationToSpawn = lightOrbsSpawnData.AvailableLocationsToSpawnLightOrbs(AmountOfLightOrbsToSpawn);

        for (int i = 0; i < AmountOfLightOrbsToSpawn; i++)
        {
            Debug.Log(SelectedLocationToSpawn[i]);
            GameObject LightOrbClone = Instantiate(LightOrbPrefabTpSpawn, AllAvailableLightOrbSpawnLocations[SelectedLocationToSpawn[i]], Quaternion.identity);
            Debug.Log("OrbSpawned");
            OrbsSpawned++;
        }
        StartSpawning = false;
        NewLightOrbsSpawned = true;
    }
    public void ResetTheNumberOfLightOrbsDestroyed()
    {
        if (NewLightOrbsSpawned)
        {
          lightOrbsSpawnData.lightOrbsdestroyed.value = 0;
          NewLightOrbsSpawned = false;
        }
    }

    void SetNumberOfOrbsRequiredToBeDestroyedToStartSpawn(int amount)
    {
        LightOrbsDestroyedToStartSpawnning = amount;
    }









}
