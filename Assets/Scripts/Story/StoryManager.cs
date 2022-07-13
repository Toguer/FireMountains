using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _storytext;
    
    public bool _buttonNext = true;
    public string nextScene;

    private int _sceneNumber;
    public int i = 0;
    public List<GameObject> storylist;

    
    private void Start()
    {
        
        _sceneNumber = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(_sceneNumber);


        StartStory(i);
    }
 
    public void StartStory(int i)
    {
        storylist[i].SetActive(true);
        //DisplayNextStory();
    }

  /*  IEnumerator NextTextTime(int i)
    {
        yield return new WaitForSeconds(0.1f);
        storylist[i].SetActive(false);
        i++;
        storylist[i].SetActive(true);

    } */

    public void DisplayNextStory()
    {
        storylist[i].SetActive(false);
        i++;
        storylist[i].SetActive(true);
    }
    

    public void EndDialogue()
    {
       // Debug.Log ("End Of conversation");
        SceneManager.LoadScene(nextScene);
    }
}
