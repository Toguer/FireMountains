using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditMenu : MonoBehaviour
{
    [SerializeField] private int sceneLoad = 0;
    public void goMainMenu()
    {
        SceneManager.LoadScene(sceneLoad);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            goMainMenu();
        }
    }
}
