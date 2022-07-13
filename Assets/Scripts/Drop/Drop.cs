using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public List<Money> posibleDrops;
    [Tooltip("0 a probability1 = 0 , de probability1 a probability2 = 1 , de probability2 hacia arriba = 2 ")]
    public int probability1, probability2;

    public void DropSomething()
    {
        int dropItem = Random.Range(0, posibleDrops.Count);
        if (posibleDrops[0] != null)
        {
            for (int i = 0; i < checkProbability(); i++)
            {
                GameObject c = Instantiate(posibleDrops[dropItem].dropItem, this.gameObject.transform);
                c.transform.parent = null;
                c.transform.position = this.gameObject.transform.parent.position;
                c.transform.localScale = new Vector3(1, 1, 1);
                //Instantiate(gameObjectCreate(posibleDrops[dropItem]), this.gameObject.transform);
                Debug.Log("Se supone que se ha creado el GameObject");
            }
        }
    }

    int checkProbability()
    {
        int randomNum = Random.Range(0, 101);
        if (randomNum > 0 && randomNum < probability1)
        {
            return 0;
        }
        else if (randomNum > probability1 && randomNum < probability2)
        {
            return 1;
        }
        else if (randomNum > probability2)
        {
            return 2;
        }
        Debug.Log("¡Numeros erroneos!");
        return 1;
    }

    /*  public GameObject gameObjectCreate(Money money)
      {
          GameObject o = new GameObject();
          o.AddComponent<SpriteRenderer>().sprite = money.Sprite;
          o.AddComponent<BoxCollider>();
          o.GetComponent<BoxCollider>().isTrigger = true;
          o.AddComponent<droppedItem>().Fruit = money;

          o.transform.position = this.gameObject.transform.position;
              return o;
      }
    */
}


