using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Sentences", order = 1)]
public class Dialogue : ScriptableObject
{
    public string name;
    
    [TextArea(3,10)]
    public string sentences;

    public Sprite sprite;

}
