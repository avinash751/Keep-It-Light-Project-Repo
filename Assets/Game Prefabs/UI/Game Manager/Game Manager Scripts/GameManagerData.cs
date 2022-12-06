using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEditor;

[CreateAssetMenu()]
public class GameManagerData : ScriptableObject
{
   public  delegate void StateFunction();
    
    [Serializable]public enum GameStates
    {
      Start,
      Play,
      Pause,
      Win,
      GameOver,
    }
    public GameStates currentState = GameStates.Start;
    public bool resetStates;

    [Header("Game Scenes")]
    public int startScene;
    public int mainGameScene;
    public int currentScene;

 
    public void RunStartState(StateFunction giveAStartFunctionToCall)
    {
            giveAStartFunctionToCall();
            currentScene = startScene;
    }

    public void TransitionToPlayState(StateFunction giveAPlayFunctionToCall)
    {
        if( currentState == GameStates.Play && currentScene != mainGameScene)
        {
           giveAPlayFunctionToCall();
           currentScene = mainGameScene;
        }
    }

    public void TransitionToWinState(StateFunction giveAGameOverFunctionToCall)
    {
        if(currentState == GameStates.Play && currentState != GameStates.GameOver && currentState != GameStates.Win)
        {
            giveAGameOverFunctionToCall();  
        }
    }

    public void TransitionToGameOverState(StateFunction giveALoseFunction)
    {

        giveALoseFunction();
    }
   

 


   

}
