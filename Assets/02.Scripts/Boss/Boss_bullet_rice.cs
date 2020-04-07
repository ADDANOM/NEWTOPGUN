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
