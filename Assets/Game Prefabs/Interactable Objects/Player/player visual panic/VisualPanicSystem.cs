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
    [SerializeField] AudioSource PanicTrack;

    [Header("High Mode Panic sound Settings")]
    [SerializeField] float highpanicVolume;
    [SerializeField] float highpanicPitch;

    bool playHeartOnce;
    bool playPanicOnce;



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
            camShake.SetCameraShakeValues(40, 0.0025f, 0);
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
            PlayPanicTrack();
            camShake.SetCameraShakeValues(55, 0.0035f, 0);
            camShake.EnableCamersShake(true, true);
        }
        else
        {
            LerpPanicVolume(0, maxModePanic);

            makePlayOnceTrue();
            heartBeat.Stop();
            MakePanicTrackBooltrue();
            
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
        if(playHeartOnce)
        {
           sound.Play();
           playHeartOnce = false;
        }   
    }
    void makePlayOnceTrue()
    {
        playHeartOnce = true;
    }

    void PlayPanicTrack()
    {
        if(playPanicOnce)
        {
          
            PanicTrack.Play();
            playPanicOnce = false;
        }
        LerpPanicTrackVolumeAndPitch(highpanicVolume, highpanicPitch);
    }

    void SetPanicTrackPitchAndVolume(float volume, float pitch)
    {
        PanicTrack.pitch = pitch;
        PanicTrack.volume = volume;
    }

    void MakePanicTrackBooltrue()
    {
        playPanicOnce = true;
        LerpPanicTrackVolumeAndPitch(0.00001f, 0.00001f);
         
    }

    void LerpPanicTrackVolumeAndPitch( float endVolume,float endPitch)
    {
        PanicTrack.volume = Mathf.Lerp(PanicTrack.volume, endVolume, Time.deltaTime * 1.5f);
        PanicTrack.pitch = Mathf.Lerp(PanicTrack.pitch, endPitch, Time.deltaTime * 1);
    }
    
}
