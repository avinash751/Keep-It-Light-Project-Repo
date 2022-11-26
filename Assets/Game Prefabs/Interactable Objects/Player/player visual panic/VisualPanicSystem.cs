using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class VisualPanicSystem : MonoBehaviour
{
    
    [SerializeField] Volume meduimModePanic;
    [SerializeField] Volume maxModePanic;
    [SerializeField] Value currentPanic;
    [SerializeField] CameraShake camShake;

    [Header("Meduim Mode Panic Settings")]
    [SerializeField] float lerpTime;
    [SerializeField] int thresholdForMeduimPanic;


    [Header("High Mode Panic Settings")]
    [SerializeField] float amplitude;
    [SerializeField] float frequency;
    [SerializeField] int thresholdForHighPanic;
    [SerializeField] AudioSource heartBeat;
    bool playOnce;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LerpInAndOutOfMeduimModePanic();
        LerpInAndOutOfHighModePanic();

    }

    void LerpInAndOutOfMeduimModePanic()
    {
        if(currentPanic.value>= thresholdForMeduimPanic && currentPanic.value<thresholdForHighPanic)
        {
            LerpPanicVolume(1, meduimModePanic);
            camShake.SetCameraShakeValues(30, 0.005f, 0);
            camShake.EnableCamersShake(true,true);
        }

        if( currentPanic.value< thresholdForMeduimPanic || currentPanic.value > thresholdForHighPanic)
        {
            LerpPanicVolume(0, meduimModePanic);
            camShake.EnableCamersShake(false,false);
        }   
    }

    void LerpInAndOutOfHighModePanic()
    {
        if(currentPanic.value>= thresholdForHighPanic)
        {
            LerpPanicVolume(0.6f, maxModePanic);
            SinLerpPanicVolume(0.6f,1, maxModePanic);
            PlayAudio(heartBeat);

            camShake.SetCameraShakeValues(40, 0.01f, 0);
            camShake.EnableCamersShake(true, true);
        }
        else
        {
            LerpPanicVolume(0, maxModePanic);
            makePlayOnceTrue();
            heartBeat.Stop();
        }
    }

    void LerpPanicVolume(float endValue, Volume volumeToChnage)
    {
        volumeToChnage.weight = Mathf.Lerp(volumeToChnage.weight, endValue, Time.deltaTime * lerpTime);
    }
    void SinLerpPanicVolume(float startValue,float endValue, Volume volumeToChnage)
    {
        volumeToChnage.weight = Mathf.Lerp(startValue, endValue, amplitude * Mathf.Sin(frequency * Time.time));
    }

    void PlayAudio(AudioSource sound)
    {
        if(playOnce)
        {
           sound.Play();
           playOnce = false;
        }   
    }
    void makePlayOnceTrue()
    {
        playOnce = true;
    }
}
