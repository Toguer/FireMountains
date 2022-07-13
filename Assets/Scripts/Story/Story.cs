using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Story", order = 1)]
public class Story : ScriptableObject
{

    public string text;

    public Sprite image;

    public bool hd;
}
