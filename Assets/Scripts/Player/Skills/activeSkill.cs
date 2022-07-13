using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeSkill : MonoBehaviour
{
    public List<Skills> allSkills;
    [SerializeField] private List<Skills> activeSkills;
    public int skillNum = 0;

    private void Start()
    {
        for (int i = 0; i <= allSkills.Count; i++)
        {
            if (saveInformation.SaveInformation.Skills[i])
            {
                activeSkills.Add(allSkills[i]);
            }
        }
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            activeSkills[skillNum].UseSkill();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            activeSkills[skillNum].stopUsingSkill();
            skillNum++;

            if (skillNum >= activeSkills.Count)
            {
                skillNum = 0;
            }
            activeSkills[skillNum].usingSkill();
        }
    }
}
