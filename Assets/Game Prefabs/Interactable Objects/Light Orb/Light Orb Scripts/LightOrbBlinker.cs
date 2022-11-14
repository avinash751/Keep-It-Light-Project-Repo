using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOrbBlinker : MonoBehaviour
{
    [SerializeField, HideInInspector] DarkOrbDestroyer lightOrb;
    [SerializeField, HideInInspector] LightOrbAmmoCountSystem orbAmmo;
    [SerializeField] float blinkAmplitude;
    [SerializeField] float blinkFrequency;

    [SerializeField] MeshRenderer mesh;
    [SerializeField] Color ColorToBlink;
    // Start is called before the first frame update
    void Start()
    {

        lightOrb = GetComponent<DarkOrbDestroyer>();
        orbAmmo = GetComponent<LightOrbAmmoCountSystem>();
        mesh = GetComponent<MeshRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        StartBlinkIngWhenAmmoZero();
    }

    void StartBlinkIngWhenAmmoZero()
    {
        if(orbAmmo.currentAmmo <1)
        {
            mesh.material.color = Color.Lerp(Color.black, ColorToBlink, blinkAmplitude * Mathf.Sin(Time.time * blinkFrequency));
            mesh.material.SetColor("_EmissionColor", Color.Lerp(Color.yellow * 10f, Color.red, blinkAmplitude * Mathf.Sin(Time.time * blinkFrequency)));
        }
    }
}
