using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBuy : MonoBehaviour
{   
    public void buyItem(ItemScriptable _ItemBuy)
    {
        _ItemBuy.Buy();
    }
}
