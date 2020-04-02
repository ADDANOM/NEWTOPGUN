using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerFire : MonoBehaviour
{

    public float fireTime = 0.2f;


    private void OnEnable()
    {
        InvokeRepeating("Fire", fireTime, fireTime);
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
    public void OnDisable()
    {
        CancelInvoke();
    }

}
