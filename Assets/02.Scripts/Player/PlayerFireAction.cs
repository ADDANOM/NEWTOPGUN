using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireAction : MonoBehaviour
{

    void Update()
    {
        this.transform.Translate(Vector3.forward * 400.0f * Time.deltaTime);
    }

}
