using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Attack : MonoBehaviour
{
    public GameObject bullet;
    // public Transform pTr;
    // public Transform pTr_2, pTr_3;
    float selectTime;
    int targetSelect;

    public Transform firePos1;
    public Transform firePos2;

    private float fireRate = 8.0f;
    private float nextfire;

    public int pooledAmount = 20;
    private List<GameObject> bullets = null;

    void Start()
    {
        // pTr_2 = GameObject.Find("Player").transform;
        // pTr_3 = GameObject.Find("newPlayer").transform;
        // pTr = pTr_3;
    }



    void fire()
    {

        var _bullet1 = Instantiate(bullet, firePos1.position, firePos1.rotation);
        var _bullet2 = Instantiate(bullet, firePos2.position, firePos2.rotation);

        _bullet1.GetComponent<Missile>();
        _bullet2.GetComponent<Missile>();

    }




    void Update()
    {

        if (Time.time >= nextfire)
        {
            fire();
            nextfire = Time.time + fireRate;
        }

        // if (Time.time > selectTime + 3.0f)
        // {
        //     selectTime = Time.time;
        //     targetSelect = Random.Range(0, 2);
        //     if (targetSelect == 0)
        //     {
        //         if (!pTr_2.gameObject.GetComponent<PlayerHealth>().PlayerDeath)
        //             pTr = pTr_2;
        //         else
        // //             pTr = pTr_3;
        // //     }
        //     else
        //     {
        //         if (!pTr_3.gameObject.GetComponent<PlayerHealth>().PlayerDeath)
        //             pTr = pTr_3;
        //         else
        //             pTr = pTr_2;
        //     }
        // }

    }
}
