using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanicBar : MonoBehaviour
{
    private Image panicBar;
    public float curPanic;
    private float minPanic = 100f;
    PanicSystem panic;

    private void Start()
    {
        panicBar = GetComponent<Image>();
        panic = FindObjectOfType<PanicSystem>();
    }
    private void Update()
    {
        curPanic = panic.curPanic;
        panicBar.fillAmount = curPanic / minPanic;
    }
}
