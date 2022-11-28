using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class CameraShake : MonoBehaviour
{
    private float time;
    [SerializeField]
    bool infinite;
    [Range(0, 50)]
    [SerializeField] float frequency;
    [Range(0, 1)]
    [SerializeField] float amplitude;

    [SerializeField] bool cameraShakeEnabled = false;
    Vector3 startPosition;
    [SerializeField] float duration;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition;
    }

    private void Update()
    {
        CameraShakeOnceWithDuration();
        InfiniteCameraShake();
    }

    void CameraShakeOnceWithDuration()
    {

        if (time < duration && cameraShakeEnabled && !infinite)
        {
            time += Time.deltaTime;
            cameraShakeEnabled = true;
            float Xshake = amplitude * Mathf.Sin(Time.time * frequency);
            float Yshake = amplitude * Mathf.Sin(Time.time * frequency);
            transform.position = startPosition = new Vector3( Xshake, Yshake,0); // adding current position of x and xshake becasue camera  is moving at x axis every frame
        }
        else if(time > duration && !infinite) 
        {
            EnableCamersShake(false,false);
        }
    }

    void InfiniteCameraShake()
    {
        if(cameraShakeEnabled && infinite)
        {
            float Xshake = amplitude * Mathf.Sin(Time.time * frequency);
            float Yshake = amplitude * Mathf.Sin(Time.time * frequency);
            transform.position += new Vector3(Xshake, Yshake, 0);
        }
    }

    public void EnableCamersShake(bool enable, bool Isinfinite)
    {
        time = 0;
        cameraShakeEnabled = enable;
        this.infinite = Isinfinite;
    }

    public void SetCameraShakeValues(float Frequency, float Amplitude, float duration)
    {
        amplitude = Amplitude;
        frequency = Frequency;
        this.duration = duration;
    }

}
