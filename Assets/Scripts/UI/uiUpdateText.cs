using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class uiUpdateText : MonoBehaviour
{
    public Money intFruit;
    private TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        updateFruit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        intFruit.onIntUpdate += updateFruit;
    }
    void updateFruit()
    {
        text.text = " "+ +intFruit.MoneyMod;
    }
}
