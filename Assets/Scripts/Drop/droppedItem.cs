using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class droppedItem : MonoBehaviour
{

    [SerializeField] private Money fruit;
    [SerializeField] private float _RotationSpeed = 60;
    [SerializeField] private float delta = 1f;
    [SerializeField] private float updownSpeed = 0.5f;

    public Money Fruit
    { get => fruit; set => fruit = value; }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            winCoins();
        }
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * (_RotationSpeed * Time.deltaTime));
        float y = Mathf.PingPong(updownSpeed * Time.time, delta);
        Vector3 pos = new Vector3(transform.position.x, y, transform.position.z);
        transform.position = pos;
    }
    public void winCoins()
    {
        fruit.getMoney(1);
        AudioManager.instance.Play("CurrencyTake");
        Destroy(transform.parent.gameObject);
    }
}
