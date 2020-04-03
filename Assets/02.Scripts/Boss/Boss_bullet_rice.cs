using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_bullet_rice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*20000.0f);
        Destroy(this.gameObject, 3.0f);
        
    }

}
