using UnityEngine;
using UnityEngine.SceneManagement;

public class basicDoor : Interactable
{

    public string nextScene;
    public GameObject secondCanvas;

    protected override void Interaction()
    {
        AudioManager.instance.Play("Door");
        SceneManager.LoadScene(nextScene);
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
            canvasInteractrable.SetActive(true);
            secondCanvas.SetActive(true);
        }

    }
    protected void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
            canvasInteractrable.SetActive(false);
            if (secondCanvas != null)
            {
                secondCanvas.SetActive(false);
            }
            
        }

    }
}
