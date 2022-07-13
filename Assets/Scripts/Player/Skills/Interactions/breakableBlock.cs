using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakableBlock : MonoBehaviour
{
    public void destroyBlock()
    {
        if(TryGetComponent(out Drop drop))
        {
            drop.DropSomething();
        }
        Destroy(transform.parent.gameObject);
    }

}
