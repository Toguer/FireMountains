using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTestSave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SaveManager.Init();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.P))
        {
            Save();
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }

    void Save()
    {
        SaveObject saveObject = new SaveObject
        {
            playerPosition = transform.position,
            playerRotation = transform.eulerAngles
        };
        string json = JsonUtility.ToJson(saveObject);
        SaveManager.Save(json);

    }

    void Load()
    {
        string saveString = SaveManager.Load();
        if(saveString != null)
        {
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            GetComponent<CharacterController>().enabled = false;
            transform.position = saveObject.playerPosition;
            GetComponent<CharacterController>().enabled = true;
            transform.eulerAngles = saveObject.playerRotation;
        }

    }


    private class SaveObject
    {
        public Vector3 playerPosition;
        public Vector3 playerRotation;
    }
}
