
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
        lightOrbsSpawnData.ResetTheNumberOfLightOrbsDestroyed();   
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
            lightOrbsSpawnData.newOrbsSpawned = 0;
            lightOrbsSpawnData.newLightOrbsSpawned = false;
            SpawnOrb();
            SetNumberOfOrbsRequiredToBeDestroyedToStartSpawn(lightOrbsSpawnData.newOrbsSpawned);
        }
    }
    void SpawnOrb()
    {
        List<Vector3> AllAvailableLightOrbSpawnLocations = lightOrbsSpawnData.availableSpawnLocationsOfLightOrbs;
        int[] SelectedLocationToSpawn = lightOrbsSpawnData.AvailableLocationsToSpawnLightOrbs(AmountOfLightOrbsToSpawn);

        for (int i = 0; i < AmountOfLightOrbsToSpawn; i++)
        {
            GameObject LightOrbClone = Instantiate(LightOrbPrefabTpSpawn, AllAvailableLightOrbSpawnLocations[SelectedLocationToSpawn[i]], Quaternion.identity);
            Debug.Log("OrbSpawned");
            lightOrbsSpawnData.newOrbsSpawned++;
        }
        StartSpawning = false;
        lightOrbsSpawnData.newLightOrbsSpawned = true;
    }
   
    void SetNumberOfOrbsRequiredToBeDestroyedToStartSpawn(int amount)
    {
        LightOrbsDestroyedToStartSpawnning = amount;
    }









}
