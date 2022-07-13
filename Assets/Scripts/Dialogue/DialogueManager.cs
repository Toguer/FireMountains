using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image image;
    
    public Queue<string> queueSentences;
    public Queue<string> queueName;
    public Queue<Sprite> queueSprite;
    
    public bool canClick = true;

    [SerializeField] private GameObject dialogueCanvas;
    public List<Dialogue> dialogueSenteces;
    
    // Use this for initialization
    void Start () {

        queueName = new Queue<string> ();
        queueSentences = new Queue<string>();
        queueSprite = new Queue<Sprite>();

        if (dialogueSenteces.Count != 0)
        {
            for (int i = 0; i < dialogueSenteces.Count; i++)
            {
                queueName.Enqueue(dialogueSenteces[i].name);
                queueSentences.Enqueue(dialogueSenteces[i].sentences);
                queueSprite.Enqueue(dialogueSenteces[i].sprite);
            }
        }
        //dialogueSenteces.Clear();
        
        StartDialogue();
        
    }
   
    public void StartDialogue ()
    {
        dialogueCanvas.SetActive(true);
        nameText.text = queueName.Dequeue();
        dialogueText.text = queueSentences.Dequeue();
        image.sprite = queueSprite.Dequeue();
        
        StartCoroutine(NextTextTime());
        //DisplayNextSentence ();
    }
    
    
    IEnumerator NextTextTime()
    {
        
        yield return new WaitForSeconds(10f);
        DisplayNextSentence();
    }
 
//click with the continue button
    public void DisplayNextSentence()
    {
 
        /*
        if (canClick == false)
        {
            StopAllCoroutines();
            canClick = true;
 
        }
 
        else  if (canClick == true) {
            canClick = false;

            if (dialogueSenteces.Count == 0)
            {
 
                EndDialogue();
                return;
            }
 
            //StartCoroutine(TypeSentence(sentence));
        }*/
        
        if (queueSentences.Count == 0)
        {
            EndDialogue();
        }
        else
        {
            StartDialogue();
        }

    }
 
    void EndDialogue(){
 
        Debug.Log ("End Of conversation");
        dialogueCanvas.SetActive(false);
    }
}
