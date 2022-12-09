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
        StateClass nextState = currentState.DoAction();
        if(nextState != null)
        {
            SwitchStates(nextState);
        }
    }
    private void Update()
    {
        RunStateMachine();
    }

    void SwitchStates(StateClass NextState)
    {
        currentState = NextState;
    }
}
