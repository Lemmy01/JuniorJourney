using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;

    [SerializeField] private GameObject pauseScreen;
    private void Awake()
    {
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }
    public void GameOver() {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }

    //Game Over Functions

    public void Restart() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
      
        Application.Quit();
    }

    public void Pause(bool status) { 

        pauseScreen.SetActive(status);
      if(status)
            Time.timeScale = 0;
        else 
            Time.timeScale = 1;
    }
    public void Next()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if (pauseScreen.activeInHierarchy) {
               Pause(false);
            }
            else
            {
                Pause(true);
            }
        }
    }
}
