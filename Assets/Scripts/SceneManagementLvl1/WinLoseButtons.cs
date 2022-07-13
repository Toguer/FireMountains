using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseButtons : MonoBehaviour
{
    [SerializeField] private GameObject confirmMainMenu;



    public void retryLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void tryMainMenu()
    {
        if (confirmMainMenu.activeInHierarchy)
        {
            confirmMainMenu.SetActive(false);
            
        }
        else
        {
            confirmMainMenu.SetActive(true);
            
        }
    }

    public void nextLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void continuePlaying()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
    }


    public void goMainMenu()
    {
        Debug.Log("MainMenu");
        SceneManager.LoadScene(0);
    }


}
