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
        GameManager.onBulletClear += BulletClear;
    }
    void OnDisable()
    {
        GameManager.onBulletClear -= BulletClear;
    }

    void BulletClear()
    {
        Destroy(this.gameObject);
    }
}
