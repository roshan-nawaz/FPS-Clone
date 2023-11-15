using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool pause = false;
    public void TogglePauseGame()
    {
        if (pause == true)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    // Pausing the game
    private void PauseGame()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pause = true;
    }

    // Resuming the game
    private void ResumeGame()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pause = false;
    }
}
