using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]private List<GameObject> _content;
    void Start()
    {
        for(int i =0; i<this.transform.childCount; i++)
        {
            _content.Add(this.transform.GetChild(i).gameObject);
        }
    }


    private void getButton()
    {
        for(int i=0; i<_content.Count; i++)
        {
            //_content[i].GetComponent<Button>()
        }
    }
}
