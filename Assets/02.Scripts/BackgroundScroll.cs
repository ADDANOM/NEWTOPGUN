using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{

    Rigidbody rg;
    float scrollSpeed;

    void Start()
    {
        scrollSpeed = 5.0f;
        rg = GetComponent<Rigidbody>();
        
    }


    void Update()
    {
        if (transform.position.z > -4000.0f)
        rg.MovePosition(transform.position + transform.forward*-1.0f*scrollSpeed);
        if (transform.position.z <= -4000.0f)
        rg.MovePosition(new Vector3(-3000,-700,4000));
        
    }
}
