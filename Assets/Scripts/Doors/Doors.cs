using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{

    [SerializeField]private int numInterruptors;
    private int pressedInterruptors=0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkInterruptors()
    {

    }

    public void pressInterruptor()
    {
        pressedInterruptors++;
        if (pressedInterruptors >= numInterruptors)
        {
            openDoor();
        }
    }
    public void openDoor()
    {
        //Aqui se añade la función para abrir la puerta. 
    }

}
