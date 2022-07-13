using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class teleportSkill : Skills
{
    [Tooltip("La distancia del teletransporte")]
    [SerializeField] private float teleportDistance;
    [Tooltip("Las Layers con las que se comprobara la colision")]
    public LayerMask tpCollide;
    private Vector3 moveDir;
    [Tooltip("Es el GameObject que se usara como guia")]
    public GameObject tpObject;
    private GameObject objectCreated;
    [SerializeField] private CharacterController _charController;
    public override void UseSkill()
    {
        if (!onCD)
        {

            StartCoroutine("callCD");
            #region teleport
            /*  RaycastHit hit;
              float targetAngle = Mathf.Atan2(1, 0) * Mathf.Rad2Deg + cam.eulerAngles.y;
              moveDir = Quaternion.Euler(0f, targetAngle, 0f) * new Vector3(-teleportDistance, 0, 0);
              if (Physics.Raycast(transform.position, moveDir, out hit, teleportDistance, tpCollide))
              {
                  transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                  Debug.DrawRay(transform.position, moveDir, Color.green, 10, true);

              }
              else
              {

                  transform.position += moveDir;
                  Debug.DrawRay(transform.position, moveDir, Color.red, 10, true);
              }
            */
            RaycastHit hit;
            float targetAngle = Mathf.Atan2(1, 0) * Mathf.Rad2Deg + transform.eulerAngles.y;
            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * new Vector3(-teleportDistance, 0, 0);
            if (Physics.Raycast(transform.position, moveDir, out hit, teleportDistance, tpCollide))
            {
                _charController.enabled = false;
                gameObject.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                _charController.enabled = true;
                Debug.DrawRay(transform.position, transform.forward, Color.red, 10, true);
                Debug.Log("Toca pared");
            }
            else
            {
                _charController.enabled = false;
                gameObject.transform.position += moveDir;
                _charController.enabled = true;
                Debug.DrawRay(transform.position, transform.forward, Color.green, 10, true);
            }
            #endregion
            AudioManager.instance.Play("Tp");
        }

    }
    private void Update()
    {
        if (_usingSkill)
        {
            RaycastHit hit;
            float targetAngle = Mathf.Atan2(1, 0) * Mathf.Rad2Deg + transform.eulerAngles.y;
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * new Vector3(-teleportDistance, 0, 0);
            if (Physics.Raycast(transform.position, moveDir, out hit, teleportDistance, tpCollide))
            {
                if (objectCreated == null)
                {

                    objectCreated = Instantiate(tpObject, hit.point, Quaternion.identity);

                    objectCreated.transform.parent = gameObject.transform;

                    /*  source.sourceTransform = cam.transform;
                      source.weight = 1;

                      objectCreated.GetComponent<ParentConstraint>().AddSource(source);
                      objectCreated.GetComponent<ParentConstraint>().constraintActive = true;
                      objectCreated.transform.position = transform.position + moveDir;
                    */
                }
                else
                {
                    objectCreated.transform.position = hit.point;
                    //      objectCreated.transform.rotation = _rotation;
                }
            }
            else
            {
                if (objectCreated == null)
                {
                    objectCreated = Instantiate(tpObject, gameObject.transform.position + moveDir, Quaternion.identity);
                    Debug.Log("Pre: " + objectCreated.transform.position);
                    objectCreated.transform.parent = gameObject.transform;

                    /*
                     _rotation = transform.rotation;
                           objectCreated.transform.parent = cam.transform;
                       source.sourceTransform = cam.transform;
                       source.weight = 1;
                       objectCreated.GetComponent<ParentConstraint>().AddSource(source);

                       objectCreated.GetComponent<ParentConstraint>().constraintActive = true;
                       objectCreated.transform.position = transform.position + moveDir;
                       objectCreated.GetComponent<ParentConstraint>().locked = true;
                       //Debug.Log("Post: "+objectCreated.transform.position);
                       //objectCreated.transform.position = transform.position + moveDir;

                       //This does the equivalent of pressing the "Activate" button
                    //   objectCreated.GetComponent<ParentConstraint>().SetRotationOffset(0, Quaternion.Inverse(0,0,0) * position
                    */
                }
                else
                {
                    objectCreated.transform.position = gameObject.transform.position + moveDir;
                }

            }

            Debug.DrawRay(transform.position, moveDir, Color.green, 0.1f, true);

        }
        else if (objectCreated != null)
        {
            Destroy(objectCreated);
        }


    }


}
