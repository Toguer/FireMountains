using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptors : Interactable
{
    private bool pressed = false;
    public Doors assignedDoor;



    protected override void Interaction()
    {
        assignedDoor.pressInterruptor();
        pressed = true;
    }
}
