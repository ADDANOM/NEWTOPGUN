using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_bullet_sphere : MonoBehaviour
{
    Transform player_tr_1;
    Transform player_tr_2;

    void Start()
    {
        Destroy(this.gameObject, 6.0f);
    }

}
