using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowSpawnBehaviour : ISpawnBehaviour
{
    
    MeshRenderer spawnDome;
    MeshRenderer darkorb;
    ParticleSystem DarkFog;
    Enemy_Spawn darkSpawner;
    SpawnBehaviour SpawnBehaviour;
    public GrowSpawnBehaviour(Enemy_Spawn darkSpawner,ParticleSystem fog, MeshRenderer spawnDome,MeshRenderer darkorb,SpawnBehaviour spawnBehaviour)
    {
        this.darkSpawner = darkSpawner;
        DarkFog = fog;
        this.spawnDome = spawnDome;
        this.darkorb = darkorb;
        SpawnBehaviour = spawnBehaviour;
    }

    public override void RunSpawnBehaviour()
    {
        ChangingSpawnerRelatedsettings();
        ChangingSpawnerColors();
        ChangeSpawnParticleSystemSettings();  
    }

    void ChangingSpawnerRelatedsettings()
    {
        darkSpawner.SpawnRadius += 5;
        darkSpawner.SpawnRateEnemy1 -= darkSpawner.SpawnRateEnemy1 > 0.5 ? 0.3f : 0;
    }

    void ChangingSpawnerColors()
    {
        spawnDome.material.color -= new Color(0.1f, 0.1f, 0.1f);
        SpawnBehaviour.glowRateIntensity += SpawnBehaviour.glowRateIntensity;
        SpawnBehaviour.glowRateIntensity = Mathf.Clamp(SpawnBehaviour.glowRateIntensity, 0, 8);

        darkorb.material.SetColor("_EmissionColor", darkorb.material.color * SpawnBehaviour.glowRateIntensity);
    }

    void ChangeSpawnParticleSystemSettings()
    {
        var emisionrate = DarkFog.emission;
        SpawnBehaviour.fogstartingrate += SpawnBehaviour.fogIncreaterate;
        SpawnBehaviour.fogstartingrate = Mathf.Clamp(SpawnBehaviour.fogstartingrate, 0, 300);
        emisionrate.rateOverTime = SpawnBehaviour.fogstartingrate;

    }

  
}
