using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected bool inRange = false;
    [SerializeField] protected GameObject canvasInteractrable;
    //public Text textInteraction;
    //[Tooltip("El texto que se mostrará por pantalla")]
    //[SerializeField] private string text;


    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
            canvasInteractrable.SetActive(true);
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
            canvasInteractrable.SetActive(false);
        }

    }

    protected void Update()
    {
        //ACCION
        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            Interaction();
        }
    }

    protected abstract void Interaction();
}
