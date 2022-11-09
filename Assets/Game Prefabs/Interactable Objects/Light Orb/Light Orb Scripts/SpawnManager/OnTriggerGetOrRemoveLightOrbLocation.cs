using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// bug summary
/// if the picup object trigger variable is true and if pla
/// 
public class OnTriggerGetOrRemoveLightOrbLocation : MonoBehaviour
{
    [SerializeField] LightOrbsInspector LightOrbSpawnDataManager;
    private List<Vector3> AvailableLightOrbSpawnLocations
    {
        get { return LightOrbSpawnDataManager.availableSpawnLocationsOfLightOrbs;}
        set { LightOrbSpawnDataManager.availableSpawnLocationsOfLightOrbs = value;}
    }

    [SerializeField] DarkOrbDestroyer OccupiedLightOrb;
    public bool IsOccupied;

    private void Start()
    {
        //LightOrbSpawnDataManager.newLightOrbsHasBeenSpawned += AddLocationWhenOrbsSpawnedWhenEmpty;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.GetComponent<DarkOrbDestroyer>()!=null && !IsOccupied)
        {
            GetCurrentLightOrb(other.gameObject.GetComponent<DarkOrbDestroyer>());

            if(!OccupiedLightOrb.IsPickedUp && !OccupiedLightOrb.YoyoShot)
            {
                Debug.Log("location removed");
                RemoveCurrentLocationFromSpawnLocationList(transform);
                IsOccupied = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (OccupiedLightOrb != null && IsOccupied && other.gameObject == OccupiedLightOrb.gameObject)
        {
            if(OccupiedLightOrb.IsPickedUp)
            {
                AddLightOrbLocationToSpawnList(transform);
                IsOccupied = false;
            }
            OccupiedLightOrb = null;
        }
    }

    private void RemoveCurrentLocationFromSpawnLocationList(Transform location)
    {
        for(int i = 0; i < AvailableLightOrbSpawnLocations.Count; i++)
        {
            if (AvailableLightOrbSpawnLocations[i] == location.position)
            {
                AvailableLightOrbSpawnLocations.RemoveAt(i);
                break;
            }
        } 
    }

    private void AddLightOrbLocationToSpawnList(Transform location)
    {
        AvailableLightOrbSpawnLocations.Add(location.position);
    }

 
    void GetCurrentLightOrb(DarkOrbDestroyer lightOrb)
    {
        OccupiedLightOrb = lightOrb;
    }   
}
