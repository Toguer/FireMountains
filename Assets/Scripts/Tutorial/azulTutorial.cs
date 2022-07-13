using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class azulTutorial : Interactable
{
    public Dialogue dialogueAzul;
    public Text Name;
    public Text Sentence;
    public Sprite image;
    public GameObject canvasDialogue;

    protected override void Interaction() //Init Dialogue
    {
        if (canvasDialogue.activeInHierarchy)
        {
            stopDialogue();
        }
        else
        {
            Name.text = dialogueAzul.name;
            Sentence.text = dialogueAzul.sentences;
            image = dialogueAzul.sprite;
            canvasDialogue.SetActive(true);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            stopDialogue();
        }
        
    }


    private void stopDialogue()
    {
        canvasDialogue.SetActive(false);
    }
}
