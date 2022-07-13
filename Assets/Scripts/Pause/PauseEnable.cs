using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseEnable : MonoBehaviour
{
    public GameObject pauseCanvas;
    public GameObject goMainMenuCanvas;
    public GameObject mainMenuButton, retryButton, ContinueButton, exitDialogue;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame();
        }
    }

    public void pauseGame()
    {
        if (pauseCanvas.activeInHierarchy)
        {
            if (goMainMenuCanvas.activeInHierarchy)
            {
                goMainMenuCanvas.SetActive(false);
            }
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            pauseCanvas.SetActive(false);
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
            pauseCanvas.SetActive(true);
            mainMenuButton.SetActive(true);
            retryButton.SetActive(true);
            ContinueButton.SetActive(true);
            exitDialogue.SetActive(false);
        }

    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void tryMainMenu()
    {
        if (goMainMenuCanvas.activeInHierarchy)
        {
            goMainMenuCanvas.SetActive(false);
            exitDialogue.SetActive(false);
            mainMenuButton.SetActive(true);
            retryButton.SetActive(true);
            ContinueButton.SetActive(true);

        }
        else
        {
            exitDialogue.SetActive(true);
            goMainMenuCanvas.SetActive(true);
            mainMenuButton.SetActive(false);
            retryButton.SetActive(false);
            ContinueButton.SetActive(false);
        }
    }

    public void goMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
