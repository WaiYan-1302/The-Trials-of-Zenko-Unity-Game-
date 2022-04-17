using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool isGamePaused = false;

    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private GameObject platformSpawner;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        StartCoroutine(WaitThreeSeconds());
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);

        Time.timeScale = 0f;
        isGamePaused = true;

    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("The game is quitted");
    }

    IEnumerator WaitThreeSeconds()
    {
        yield return new WaitForSeconds(3.0f);
    }
}
