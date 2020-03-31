using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZMove : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveControll();
    }

    void MoveControll()
    {
        float zMove = moveSpeed * Time.deltaTime;
        transform.Translate(0, 0, zMove);
    }
}
