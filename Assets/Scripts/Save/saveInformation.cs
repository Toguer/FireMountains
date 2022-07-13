using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveInformation : MonoBehaviour
{
    private List<bool> _skills;
    private bool _tutorial;
    private bool _panadera, _npc1, _npc2, _npc3;
    public static saveInformation SaveInformation;


    public bool Panadera { get => _panadera; set => _panadera = value; }
    public bool Npc1 { get => _npc1; set => _npc1 = value; }
    public bool Npc2 { get => _npc2; set => _npc2 = value; }
    public bool Npc3 { get => _npc3; set => _npc3 = value; }
    public List<bool> Skills { get => _skills; set => _skills = value; }

    void Awake()
    {
        SaveInformation = this;
        Skills = new List<bool>();
        DontDestroyOnLoad(this.gameObject);
    }



    public void loadHere(bool skill1, bool skill2, bool skill3, bool panadera, bool npc1, bool npc2, bool npc3)
    {
        Skills.Add(skill1);
        Skills.Add(skill2);
        Skills.Add(skill3);
        _tutorial = false;
        Panadera = panadera;
        Npc1 = npc1;
        Npc2 = npc2;
        Npc3 = npc3;
    }

}
