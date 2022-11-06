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
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.GetComponent<DarkOrbDestroyer>()!=null && !IsOccupied)
        {
            GetCurrentLightOrb(other.gameObject.GetComponent<DarkOrbDestroyer>());

            if(!OccupiedLightOrb.IsThrowable)
            {
                RemoveCurrentLocationFromSpawnLocationList(transform);
                IsOccupied = true;
                Debug.Log(transform.gameObject + " got current orb location");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (OccupiedLightOrb != null && IsOccupied && other.gameObject == OccupiedLightOrb.gameObject)
        {
            if(OccupiedLightOrb.IsThrowable)
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
                Debug.Log(transform.gameObject + " light orb location removed from spawn list");
                break;
            }
        } 
    }

    private void AddLightOrbLocationToSpawnList(Transform location)
    {
        AvailableLightOrbSpawnLocations.Add(location.position);
        Debug.Log(transform.gameObject + " light orb location added tospawn list");
    }

 
    void GetCurrentLightOrb(DarkOrbDestroyer lightOrb)
    {
        OccupiedLightOrb = lightOrb;
    }
}
