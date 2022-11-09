using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameManagerData gameData;
    [SerializeField] Value darkOrbsDestroyed;
    [SerializeField] int amountOfOrbsRequiredToWin;

    [Header("Game Menues")]
    [SerializeField] GameObject startmenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject gameOverMenu;

    [Header("PlayerUI")]
    [SerializeField] GameObject playerPanic;



    void Awake()
    {
        startmenu = transform.GetChild(0).gameObject;
        winMenu = transform.GetChild(1).gameObject;
    }
    public void Start()
    {
        gameData.SetGameToStart();
        gameData.RunStartState(StartGameFunction);
    }
    public void Update()
    {
        gameData.TransitionToPlayState(PlayGameFunction);
        gameData.TransitionToWinState(WinGameFunction);
    }


    // State based Functions
    public void StartGameFunction()
    {
        darkOrbsDestroyed.value = 0;
        SetCursorState(CursorLockMode.None);
       
    }
    void PlayGameFunction()
    {
        LoadScene(gameData.mainGameScene);
        startmenu.SetActive(false);
        SetCursorState(CursorLockMode.Locked);
        Time.timeScale = 1;   
    }
    void WinGameFunction()
    {
        if (darkOrbsDestroyed.value >= amountOfOrbsRequiredToWin)
        {
            gameData.currentState = GameManagerData.GameStates.Win;
            winMenu.SetActive(true);
            playerPanic.SetActive(false);
            StopGame();
        }
    }
    public void RestartGameFunction()
    {
        SetGameState("Start");
        LoadScene(gameData.startScene);
        Time.timeScale = 1;
    }




    // helper functions for the game manager 
    void StopGame()
    {
        SetCursorState(CursorLockMode.None);
        Time.timeScale = 0f;   
    }
    public void Exitgame()
    {
        Application.Quit();
    }
    void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    void SetCursorState(CursorLockMode mouseState)
    {
        Cursor.lockState = mouseState;
    }
    public void SetGameState(string state)
    {
        gameData.currentState = (GameManagerData.GameStates)System.Enum.Parse(typeof(GameManagerData.GameStates),state);
        Debug.Log(gameData.currentState);
    }
}