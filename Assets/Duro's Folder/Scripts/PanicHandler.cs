using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanicHandler : MonoBehaviour
{
    private void Start()
    {
        PanicSystem panicSystem = new PanicSystem(0);

        Debug.Log("Panic: " + panicSystem.GetPanic());
        panicSystem.Damage(10);
        Debug.Log("Panic: " + panicSystem.GetPanic());
        panicSystem.Heal(10);
        Debug.Log("Panic: " + panicSystem.GetPanic());

    }
}
