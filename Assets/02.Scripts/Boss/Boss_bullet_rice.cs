using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_bullet_rice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 3.0f);
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
