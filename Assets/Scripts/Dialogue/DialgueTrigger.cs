using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialgueTrigger : MonoBehaviour
{
    //cambiar el findobject
    
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue();
    }
}
