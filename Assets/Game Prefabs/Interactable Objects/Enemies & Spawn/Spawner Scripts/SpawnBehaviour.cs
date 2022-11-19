using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour
{
    [SerializeField] Enemy_Spawn darkSpawn;
    [SerializeField] MeshRenderer darkOrb;
    ISpawnBehaviour spawnBehaviour;

    [Header("grow behaviour settings")]
    public int fogstartingrate;
    public int fogIncreaterate;
    public int glowRateIntensity;
    public float  enemy1SpawnRateRateAddon;

    [SerializeField] float RateOfGrowing;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(AfterCertainTimeLetSpawnerGrow), RateOfGrowing, RateOfGrowing);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void  AfterCertainTimeLetSpawnerGrow()
    {
        spawnBehaviour = new GrowSpawnBehaviour(darkSpawn, darkSpawn.DarkFog.GetComponent<ParticleSystem>(), darkSpawn.SpawnDome.GetComponent<MeshRenderer>(), darkOrb,this);
        spawnBehaviour.RunSpawnBehaviour();
    }
}
