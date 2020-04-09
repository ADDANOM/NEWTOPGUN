using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSubFire : MonoBehaviour
{
    float lastShot;

    private void Start()
    {
        lastShot = Time.time;
    }

    private void Update()
    {
        //InvokeRepeating("Fire", 0.05f, fireTime);
        if (Time.time > lastShot + 0.5f)
        {
            lastShot = Time.time;
            Fire();
        }
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
    // public void OnDisable()
    // {
    //     CancelInvoke();
    // }

}
