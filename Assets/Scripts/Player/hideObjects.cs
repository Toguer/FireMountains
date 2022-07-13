using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class hideObjects : MonoBehaviour
{
    public GameObject mainCamera;
    public RaycastHit[] hits;
    public List<GameObject> invisibleParent;
    public LayerMask layerInvisible;
    // Start is called before the first frame update
    private void Start()
    {
        invisibleParent = new List<GameObject>();
    }
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, mainCamera.transform.position - transform.position, Color.black, 0.01f);

        hits = Physics.RaycastAll(transform.position, mainCamera.transform.position - transform.position, Vector3.Distance(transform.position, mainCamera.transform.position), layerInvisible);
        //Debug.Log("En el Array 0: " + hits[0].collider.name);
        if (hits.Length > 0)
        {
            List<GameObject> hitGameObjects = new List<GameObject>();

            foreach (RaycastHit col in hits)
            {
                GameObject objectParent = checkParent(col.collider.gameObject);
                Debug.Log("Padre top: " + checkParent(col.collider.gameObject).name);
                //invisibleParent.Add(objectParent);
                hitGameObjects.Add(objectParent);
                //checkMesh(objectParent);
                checkChilds(objectParent);
                if (!invisibleParent.Contains(objectParent))
                {
                    invisibleParent.Add(objectParent);
                }

            }
            foreach (GameObject meshR in invisibleParent.ToList())
            {
                if (!hitGameObjects.Contains(meshR))
                {
                    checkChildMesh(meshR);
                }
            }


        }
        else
        {
            foreach (GameObject invisibleItem in invisibleParent.ToList())     //Recorremos todos los hijos de los objetos guardados en invisibleParent para reactivar su Mesh
            {                                                                   //y borramos el padre de la lista. 

                checkChildMesh(invisibleItem);
                invisibleParent.Remove(invisibleItem);
            }
        }




    }

    GameObject checkParent(GameObject gameO)
    {
        if (gameO.transform.parent.gameObject.TryGetComponent<MeshCollider>(out MeshCollider component))
        {
            return checkParent(gameO.transform.parent.gameObject);
        }
        else
        {
            return gameO;
        }
    }

    void checkChilds(GameObject gameobject) //Sirve para desactivar los meshes de todos los hijos
    {
        if (gameobject.transform.childCount > 0)
        {
            List<GameObject> gameObjectList = new List<GameObject>();
            for (int i = 0; i < gameobject.transform.childCount; i++)
            {
                gameObjectList.Add(gameobject.transform.GetChild(i).gameObject);
            }
            foreach (GameObject gameObjects in gameObjectList)
            {
                //checkMesh(gameObjects);
                checkChilds(gameObjects);
            }

        }
        checkMesh(gameobject);
    }



    void checkMesh(GameObject gameObject)
    {
        if (gameObject.TryGetComponent<MeshRenderer>(out MeshRenderer component))
        {
            disableMeshRenderer(component);
        }
    }

    void disableMeshRenderer(MeshRenderer meshRenderer)
    {
        meshRenderer.enabled = false;

        /* if (!invisibleGameObjects.Contains(meshRenderer))
         {
             invisibleGameObjects.Add(meshRenderer);
         }*/
    }
    void enableMeshRenderer(MeshRenderer meshRenderer)
    {
        Debug.Log("Triying to enable: " + meshRenderer.gameObject.name);
        meshRenderer.enabled = true;
        //invisibleParent.Remove(meshRenderer);
    }

    void checkChildMesh(GameObject meshR)
    {
        Debug.Log(meshR.name + " tiene " + meshR.transform.childCount + " hijos");
        if (meshR.transform.childCount > 0)
        {
            Debug.Log("Tiene hijos entra al bucle");
            List<MeshRenderer> gameObjectList = new List<MeshRenderer>();
            for (int i = 0; i < meshR.transform.childCount; i++)
            {
                if (meshR.transform.GetChild(i).TryGetComponent<MeshRenderer>(out MeshRenderer meshRen))
                {
                    gameObjectList.Add(meshRen);
                }
                else
                {
                    checkChildMesh(meshR.transform.GetChild(i).gameObject);
                }
            }
            Debug.Log("gameObjectList.Count "+gameObjectList.Count);
            foreach (MeshRenderer gameObjects in gameObjectList)
            {
                Debug.Log(gameObjects.gameObject.name);
                checkChildMesh(gameObjects.gameObject);
                enableMeshRenderer(gameObjects);
            }
        }
        if(meshR.TryGetComponent<MeshRenderer>(out MeshRenderer meshRe))
        {
            enableMeshRenderer(meshRe);

        }
    }

}