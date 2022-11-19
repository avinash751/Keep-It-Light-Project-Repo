using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanicBar : MonoBehaviour
{
    private Image panicBar;
    [SerializeField] Value curentPanic;
    [SerializeField] Value maxPanic;
    PanicSystem panic;

    private void Start()
    {
        panicBar = GetComponent<Image>();
    }
    private void Update()
    {
        UpdatePanicBarValue();
    }

    void UpdatePanicBarValue()
    {
        panicBar.fillAmount = curentPanic.value / 100f;
    }
}
