using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Items", order = 1)]
public class ItemScriptable : ScriptableObject
{
    [Tooltip("La moneda con la que compraras")]
    public Money priceCoin;
    [Tooltip("Cuantas de estas monedas cuesta comprar X de las otras, X es numBuyCoin")]
    public int numPriceCoin;
    [Tooltip("La moneda que compraras")]
    public Money buyCoin;
    [Tooltip("Cuantas monedas recibes a cambio")]
    public int numBuyCoin;



    public void Buy()
    {
        buyCoin.getMoney(numBuyCoin);
        priceCoin.loseMoney(numPriceCoin);
    }


}
