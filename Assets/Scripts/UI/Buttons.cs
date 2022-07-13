using UnityEngine;
//using UnityEditor.UI;
using UnityEngine.EventSystems;

public class Buttons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool buttonPressed;
    public void OnPointerDown(PointerEventData eventData)
    {
        AudioManager.instance.Play("ButtonPress");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        AudioManager.instance.Play("PointerUp"); 
    }

}
