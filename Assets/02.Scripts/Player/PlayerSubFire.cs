using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSubFire : MonoBehaviour
{

    public float fireTime = 0.5f;


    private void OnEnable()
    {
        InvokeRepeating("Fire", 0.05f, fireTime);
    }

    void Fire()
    {
        GameObject obj = PlayerSubFirePooler.current.GetPooledObejcr();

        if (obj == null)
            return;

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);

    }
    public void OnDisable()
    {
        CancelInvoke();
    }

}
