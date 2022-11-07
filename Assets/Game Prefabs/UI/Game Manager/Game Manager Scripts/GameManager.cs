using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject startmenu;
    [SerializeField] GameObject winMenu;
    [SerializeField] Value darkOrbsDestroyed;
    [SerializeField] int amountOfOrbsRequiredToWin;
   

    

    public void Start()
    {
       darkOrbsDestroyed.value = 0;
       StopGame();
       winMenu.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        WinGame();
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        
       startmenu.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void WinGame()
    {
        if(darkOrbsDestroyed.value>= amountOfOrbsRequiredToWin)
        {
            winMenu.SetActive(true);
            StopGame();
        }
    }

    public void StopGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
       
    }

    public void Existgame()
    {
        Application.Quit();
    }
}
