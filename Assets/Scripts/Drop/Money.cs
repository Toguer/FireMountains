using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/IntScriptable", order = 1)]
public class Money : ScriptableObject
{
    [SerializeField]private int money = 0;
    public string _name;
    public int id;
    public GameObject dropItem;

    public GameObject Sprite { get => dropItem; set => dropItem = value; }
    public int MoneyMod { get => money; set => money = value; }

    public event Action onIntUpdate = delegate { };

    public void getMoney(int num)
    {
        MoneyMod += num;
        Debug.Log("Get Money");
        OnValidate();
    }
    public void loseMoney(int num)
    {
        MoneyMod -= num;
        Debug.Log("Lose Money");
        OnValidate();
    }

    private void OnValidate()
    {
        onIntUpdate.Invoke();
    }
}
