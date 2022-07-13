using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject canvasExit;

    public void StartGame()
    {
        AudioManager.instance.Play("PlayButton");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void Settings()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       
    }
    public void tryExit()
    {
        if (canvasExit.activeInHierarchy)
        {
            canvasExit.SetActive(false);
        }
        else
        {
            canvasExit.SetActive(true);
        }

    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ExitGame()
    {
        Debug.Log("Exit game");
        Application.Quit();
    }

}
