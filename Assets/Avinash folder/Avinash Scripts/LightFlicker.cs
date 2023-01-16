using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    Light light;
    public float minIntensity = 0.2f;
   public  float maxIntensity;
    public float randomness;
    public float lerpSpeed;

    void Start()
    {
        
        light = GetComponent<Light>();
    }

    void Update()
    {
        light.intensity = Mathf.Lerp(light.intensity,Mathf.PerlinNoise(randomness * Time.time, 0f) * maxIntensity, Time.deltaTime * lerpSpeed);
    }
}