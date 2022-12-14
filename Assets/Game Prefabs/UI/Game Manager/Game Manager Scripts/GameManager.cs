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
    [SerializeField] Value currentPanic;
    [SerializeField] Value maxPanic;
    [SerializeField] int amountOfOrbsRequiredToWin;

    [Header("Game Menues")]
    [SerializeField] UnityEngine.GameObject startmenu;
    [SerializeField] UnityEngine.GameObject pauseMenu;
    [SerializeField] UnityEngine.GameObject winMenu;
    [SerializeField] UnityEngine.GameObject gameOverMenu;

    [Header("PlayerUI")]
    [SerializeField] UnityEngine.GameObject playerPanic;



    void Awake()
    {

        startmenu = transform.GetChild(0).gameObject;
        winMenu = transform.GetChild(1).gameObject;
    }
    public void Start()
    {
        darkOrbsDestroyed.value = 0;
        currentPanic.value = 0;
        Time.timeScale = 1;
        gameData.RunStartState(StartGameFunction);
    }
    public void Update()
    {
     
        gameData.TransitionToWinState(WinGameFunction);
        gameData.TransitionToGameOverState(LoseGameFunction);
        ResetToHub();
    }


    // State based Functions
    public void StartGameFunction()
    {
        var currScene = SceneManager.GetActiveScene().buildIndex;
        if(currScene == 0)
        {
            SetCursorState(CursorLockMode.None);
            Time.timeScale = 1;
            startmenu.SetActive(true);
            winMenu.SetActive(false);
            gameOverMenu.SetActive(false);
            gameData.currentState = GameManagerData.GameStates.Start;
        }
    }
    public void PlayGameFunction()
    {
        LoadScene(gameData.mainGameScene);
        startmenu.SetActive(false);
        winMenu.SetActive(false);
        gameOverMenu.SetActive(false);

        SetCursorState(CursorLockMode.Locked);
        Time.timeScale = 1;
        gameData.currentState = GameManagerData.GameStates.Play;
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


    void LoseGameFunction()
    {
       if(currentPanic.value >= maxPanic.value)
       {
            StopGame();
            gameOverMenu.SetActive(true);
            playerPanic.SetActive(false);
            SetGameState("GameOver");
       }
    }
    public void RestartGameFunction()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
        SetGameState("Start");
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


    void ResetToHub()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            LoadScene(5);
        }
    }
}
