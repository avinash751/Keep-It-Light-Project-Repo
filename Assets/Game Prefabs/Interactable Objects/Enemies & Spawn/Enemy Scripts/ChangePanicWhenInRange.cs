using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePanicWhenInRange : MonoBehaviour
{
    EnemyHealth enemyHealth;
    FpsMovment player;

    [SerializeField] float  DistanceThresholdToIncreasePanic;
    [SerializeField] int PanicToIncrease;
    [SerializeField] int PanicToDecrease;
    [SerializeField]bool IncreasePanic;
    [SerializeField] float distnace;

    // Start is called before the first frame update
    void Start()
    {
       enemyHealth = GetComponent<EnemyHealth>();
       player = FindObjectOfType<FpsMovment>();
    }

    void Update()
    {
        IncreasePanicWhenPlayerInRange();
        DecreasePanicWhenPlayerNotInRange();
    }

    float  DistnaceFromPlayer()
    {
        var distanceFromplayer = Vector3.Distance(transform.position, player.transform.position);
        distnace = distanceFromplayer;
        return distanceFromplayer;
    }

    void IncreasePanicWhenPlayerInRange()
    {
        if(DistnaceFromPlayer()<= DistanceThresholdToIncreasePanic && !IncreasePanic)
        {
            enemyHealth.IncreasePanic(PanicToIncrease);
            IncreasePanic = true;
        }
    }

    void DecreasePanicWhenPlayerNotInRange()
    {
        if (DistnaceFromPlayer() > DistanceThresholdToIncreasePanic && IncreasePanic)
        {
            enemyHealth.currentPanic.value -= PanicToDecrease;
            IncreasePanic = false;
        }
    }


}
