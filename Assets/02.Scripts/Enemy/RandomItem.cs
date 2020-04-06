using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItem : MonoBehaviour
{
    float MoveSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Boxmove();
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this);
    }
    
    void Boxmove()
    {
        float zMove = MoveSpeed * Time.deltaTime;
        transform.Translate(0, 0, zMove);
    }
}
