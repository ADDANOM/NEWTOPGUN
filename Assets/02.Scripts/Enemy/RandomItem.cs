using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItem : MonoBehaviour
{
    float MoveSpeed = 10.0f;

    GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        item = transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Boxmove();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Player"))
        {
            Destroy(item);
        }
    }
    
    void Boxmove()
    {
        float zMove = MoveSpeed * Time.deltaTime;
        transform.Translate(0, 0, zMove);

        Destroy(item, 7.0f);
    }
}
