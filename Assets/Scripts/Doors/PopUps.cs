using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopUps : Interactable
{
    [SerializeField] private GameObject _popupCanvas;
    //[SerializeField] private TextMeshProUGUI _textpop;
    public Dialogue dialogueAzul;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Sentence;
    public Image image;
    public GameObject canvasDialogue;
    private Animator childAnimator;


    private void Awake()
    {
        if (_popupCanvas != null)
        {
            if (!_popupCanvas.activeInHierarchy)
            {
                _popupCanvas.SetActive(true);
                if (canvasDialogue.activeInHierarchy)
                {
                    canvasDialogue.SetActive(false);
                }
            }
        }

    }

    private void Start()
    {
        childAnimator = GetComponentInChildren<Animator>();
    }

    protected override void Interaction() //Init Dialogue
    {
        Debug.Log("Interaction");
        if (canvasDialogue.activeInHierarchy)
        {
            stopDialogue();
            canvasInteractrable.SetActive(true);
        }
        else
        {
            if(childAnimator!=null)
            childAnimator.SetBool("Hablando", true);
            canvasInteractrable.SetActive(false);
            Name.text = dialogueAzul.name;
            Sentence.text = dialogueAzul.sentences;
            if (dialogueAzul.sprite != null)
            {
                Debug.Log("not null");
                image.enabled = true;
                image.sprite = dialogueAzul.sprite;
            }
            else
            {
                image.enabled = false;
            }
            canvasDialogue.SetActive(true);
            if (TryGetComponent<EnemigoIA>(out EnemigoIA component))
            {
                component.Talking = true;
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        //inRange = false;
        //canvasInteractrable.SetActive(false);
        if (other.CompareTag("Player"))
        {
            stopDialogue();
        }

    }
    private void stopDialogue()
    {
        canvasDialogue.SetActive(false);
        if (TryGetComponent<EnemigoIA>(out EnemigoIA component))
        {
            component.Talking = false;
        }
        childAnimator.SetBool("Hablando", false);
    }
}
