using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("The game quitted");

        Application.Quit();
    }

    public void ResumeGame()
    {
        Debug.Log("The game will continue");
    }
}
