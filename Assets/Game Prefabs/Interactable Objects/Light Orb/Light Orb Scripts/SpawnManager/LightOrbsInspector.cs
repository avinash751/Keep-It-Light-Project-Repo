using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.PlayerLoop;

[CreateAssetMenu()]
public class LightOrbsInspector : ScriptableObject
{
   
    public Value lightOrbsdestroyed;
    public int LightOrbsDestroyed
    { 
        get { return lightOrbsdestroyed.value;}

        set { lightOrbsdestroyed.value = value; }
    }

    public  List<Vector3> availableSpawnLocationsOfLightOrbs;

   

    public int[] AvailableLocationsToSpawnLightOrbs(int amountOfLocations )
    {
        
        int[] LocationsToSpawn = new int[amountOfLocations];
       

        for (int i = 0; i < amountOfLocations; i++)
        {
            LocationsToSpawn[i] = Random.Range(0, (availableSpawnLocationsOfLightOrbs.Count));

        }
        
        if(LocationsToSpawn.Length<=1)
        {
            return LocationsToSpawn;
        }
        else
        {
            LocationsToSpawn = CheckIfEveryLocationIsUnique(LocationsToSpawn);
            return LocationsToSpawn;

        }
    }

    

    public int[] CheckIfEveryLocationIsUnique(int[]locationarray)
    {
        for (var i = 0; i < locationarray.Length;)
        {
            for(var j = 1; j < locationarray.Length;)
            {
                if(i!=j)
                {
                    if(locationarray[i] == locationarray[j])
                    {
                       locationarray[i] = Random.Range(0, (availableSpawnLocationsOfLightOrbs.Count));
                        i = 0;
                        j = 1;
                    }
                    else
                    {
                        j++;
                    }
                }
                else
                {
                    break;
                }
            }
            if(i==locationarray.Length)
            {
                break;
            }
            else
            {
                i++;
            }
            
        }
        return locationarray;
    }
    

}
