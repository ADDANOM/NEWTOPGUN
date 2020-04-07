using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Attack : MonoBehaviour
{
    public GameObject bullet;
    public Transform pTr;

    public Transform firePos1;
    public Transform firePos2;

    private float fireRate = 3.0f;
    private float nextfire;

    public int pooledAmount = 20;
    private List<GameObject> bullets = null;

    void Start()
    {
        
        fire();
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
    }
}
