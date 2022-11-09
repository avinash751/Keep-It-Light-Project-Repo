using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanicSystem 
{
    private int curPanic;
    private int panicMax;

    public PanicSystem (int panicMax)
    {
        this.panicMax = panicMax;
        curPanic = panicMax;
    }

    public int GetPanic()
    {
        return curPanic;
    }

    public void Damage(int damageAmout)
    {
        curPanic += damageAmout;
        if (curPanic > 100)
        {
            curPanic = 100;
        }
    }

    public void Heal(int healAmount)
    {
        curPanic -= healAmount;
        if (curPanic <= 0)
        {
            curPanic = 0;
        }
    }
}
