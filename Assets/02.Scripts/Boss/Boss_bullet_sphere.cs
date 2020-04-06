using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_bullet_sphere : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 6.0f);
    }


    void OnEnable()
    {
        Boss_Attack.OnBulletClear += BulletClear;
    }
    void OnDisable()
    {
        Boss_Attack.OnBulletClear -= BulletClear;
    }

    void BulletClear()
    {
        Destroy(this.gameObject);
    }
}
