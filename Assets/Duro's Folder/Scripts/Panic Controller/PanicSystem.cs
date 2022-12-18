using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanicSystem: MonoBehaviour
{

    [SerializeField] Value currentPanic;
    [SerializeField] Value maxPanic;
    [SerializeField] int PanicToDecreaseOvertime;
    public float PanicOvertimeDecreaseRate;

    private void Start()
    {
        currentPanic.value = 0;
        InvokeRepeating(nameof(ReducePanicOverTime), PanicOvertimeDecreaseRate, PanicOvertimeDecreaseRate);
    }
    public int GetPanic()
    {
        return currentPanic.value;
    }

    public  void IncreasePanic(int panicAmount)
    {
        currentPanic.value += panicAmount;
        Debug.Log(currentPanic);
        ClampPanicValue();
    }


    public void Heal(int healAmount)
    {
        currentPanic.value -= healAmount;
        ClampPanicValue();
    }

    void ClampPanicValue()
    {
        currentPanic.value = Mathf.Clamp(currentPanic.value, 0, maxPanic.value);
    }

    private void Update()
    {
        ClampPanicValue();
    }

    void ReducePanicOverTime()
    {
        currentPanic.value -= PanicToDecreaseOvertime;
    }
    
}
