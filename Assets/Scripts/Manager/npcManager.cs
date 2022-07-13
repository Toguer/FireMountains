using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcManager : MonoBehaviour
{
    [SerializeField] private GameObject _panadera;
    [SerializeField] private GameObject _npc1;
    [SerializeField] private GameObject _npc2;
    [SerializeField] private GameObject _npc3;

    public GameObject Panadera { get => _panadera; set => _panadera = value; }
    public GameObject Npc1 { get => _npc1; set => _npc1 = value; }
    public GameObject Npc2 { get => _npc2; set => _npc2 = value; }
    public GameObject Npc3 { get => _npc3; set => _npc3 = value; }

    private void Start()
    {
        _panadera.SetActive(saveInformation.SaveInformation.Panadera);
        _npc1.SetActive(saveInformation.SaveInformation.Npc1);
        _npc2.SetActive(saveInformation.SaveInformation.Npc2);
        _npc3.SetActive(saveInformation.SaveInformation.Npc3);
    }
}
