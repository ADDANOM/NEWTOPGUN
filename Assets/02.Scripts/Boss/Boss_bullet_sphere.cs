using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_bullet_sphere : MonoBehaviour
{
    Transform player_tr_1;
    Transform player_tr_2;

    void Start()
    {
        player_tr_1 = GameObject.Find("Player").transform;
        Debug.Log(transform.position - player_tr_1.position);
        GetComponent<Rigidbody>().AddRelativeForce(new Vector3(transform.position.x - player_tr_1.position.x, player_tr_1.position.y - transform.position.y, transform.position.z - player_tr_1.position.z)
        * 50.0f);
        Destroy(this.gameObject, 6.0f);

    }

}
