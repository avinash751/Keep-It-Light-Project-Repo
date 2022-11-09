/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanicController : MonoBehaviour
{
    [Header("Panic Main Parameters")]
    public float playerPanic = 100.0f;
    [SerializeField] private float minPanic = 100.0f;
    [SerializeField] private float enemiesAroundCost = 5f;
    [HideInInspector] public bool hasRegenerated = true;
    [HideInInspector] public bool inEnemyVicinity = false;

    [Header("Panic Affecting rate")]
    [Range (0,50)] [SerializeField] private float PanicDrain = 0.5f;
    [Range(0, 50)] [SerializeField] private float PanicRegen = 0.5f;

    [Header("Panic by Enemy")]
    [SerializeField] private int slowedRunSpeed = 4;
    [SerializeField] private int normalrunSpeed = 8;

    [Header("Panic UI Element")]
    [SerializeField] private Image panicDegressUI = null;
    [SerializeField] private CanvasGroup sliderCanvasGroup = null;


    private FpsMovment playerController;

    private void Start()
    {
        playerController = GetComponent<FpsMovment>();
    }

    private void Update()
    {
        if(!inEnemyVicinity)
        {
            if(playerPanic <= minPanic - 0.01)
            {
                playerPanic += PanicRegen * Time.deltaTime;
                //update panic

                if(playerPanic >= minPanic)
                {
                    hasRegenerated = true;
                }
            }
        }
    }

    void UpdatePanic(int value)
    {
        panicDegressUI.fillAmount = playerPanic / minPanic;

        if (value == 0)
        {
            sliderCanvasGroup.alpha = 0;
        }
        else
        {
            sliderCanvasGroup.alpha = 1;
        }
    }

}
/*/
