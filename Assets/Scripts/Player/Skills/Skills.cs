using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skills : MonoBehaviour
{
    [Tooltip("Es el tiempo que tiene que pasar hasta volver a usar la Habilidad")]
    public float coolDown;
    [Tooltip("No lo usamos aun, asi que si lo tocas no pasa nada :3")]
    public int skillId;
    protected bool _usingSkill = false;
    protected bool onCD = false;

    public abstract void UseSkill();

    protected IEnumerator callCD()
    {
        Debug.Log("CallCD");
        onCD = true;
        yield return new WaitForSeconds(coolDown);
        onCD = false;
    }

    public void usingSkill()
    {
        _usingSkill = true;
    }

    public void stopUsingSkill()
    {
        _usingSkill = false;
    }
}
