using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public StateClass currentState;

    public void Start()
    {
        currentState = GetComponent<RoamBehaviour>();
    }

    public void RunStateMachine()
    {
        currentState.DoAction();
    }
}
