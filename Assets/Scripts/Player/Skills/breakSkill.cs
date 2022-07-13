using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakSkill : Skills
{
    [SerializeField] private float radius;
    private RaycastHit[] _hit;

    public override void UseSkill()
    {
        if (!onCD)
        {
            Debug.Log("Break Skill use");
            _hit = Physics.SphereCastAll(transform.position, radius, Vector3.forward);

            for (int i = 0; i < _hit.Length; i++)
            {
                if (_hit[i].transform.gameObject.tag == "breakableBlocks")
                {
                    _hit[i].transform.gameObject.GetComponent<breakableBlock>().destroyBlock();
                    AudioManager.instance.Play("Destroy");
                }
            }
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
