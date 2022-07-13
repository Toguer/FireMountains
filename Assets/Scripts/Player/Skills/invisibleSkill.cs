using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class invisibleSkill : Skills
{
    [Tooltip("Aqui hay que arrastrar el objeto que tiene el material")]
    public GameObject materialGameObject;
    [SerializeField]private float durationSkill;
    private int originLayer;
    [SerializeField] private int invisibleLayer;
    [Tooltip("Aqui hay que arrastrar el material normal de Noah")]
    public Material normalMaterial;
    [Tooltip("Aqui hay que arrastrar el material invisible de Noah")]
    public Material invisibleMaterial;

    private void Start()
    {
        originLayer = this.gameObject.layer;
    }
    public override void UseSkill()
    {
        if (!onCD)
        {
            StartCoroutine("invisible");
        }
            
    }
    //Para que pueda atravesar el bloque, la pared en cuestion tiene que tener de layer= wallsInvisible y por si acaso la tag = "canPass"
    IEnumerator invisible()
    {
        StartCoroutine("callCD");
        AudioManager.instance.Play("InvisibleStart");
        this.gameObject.layer = invisibleLayer;
        materialGameObject.GetComponent<Renderer>().material = invisibleMaterial;
        Debug.Log("Invisible!");
        yield return new WaitForSeconds(durationSkill);
        AudioManager.instance.Stop("InvisibleStart");
        AudioManager.instance.Play("InvisibleStop");
        Debug.Log("NotInvisible");
        this.gameObject.layer = originLayer;
        materialGameObject.GetComponent<Renderer>().material = normalMaterial;
    }

}
