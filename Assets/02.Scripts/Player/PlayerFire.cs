using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerFire : MonoBehaviour
{
    float lastShot;

    public float fireTime = 0.2f;

    private void Start()
    {
        lastShot = Time.time;
    }

    private void Update()
    {
        // InvokeRepeating("Fire", 0.05f, fireTime);
        if(Time.time > lastShot + 0.2f){
            lastShot = Time.time;
            Fire();
        }

    }

    void Fire()
    {
        GameObject obj = PlayerFirePooler.current.GetPooledObejcr();

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
