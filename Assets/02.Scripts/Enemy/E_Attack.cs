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
        //bullets = new List<GameObject>();

        //for(int i = 0; i < pooledAmount; i++)
        //{
        //    GameObject obj = (GameObject)Instantiate(bullet);
        //    obj.SetActive(false);
        //    bullets.Add(obj);
        //}

        //InvokeRepeating("fire", 1.0f, fireRate);
        fire();
    }

    

     void fire()
    {
        //for(int i = 0; i<pooledAmount; i++)
        //{
        //    if(bullets[i].activeSelf == false)
        //    {
        //        bullets[i].transform.position = firePos1.position;
        //        bullets[i].transform.rotation = firePos1.rotation;

        //        bullets[i+1].transform.position = firePos2.position;
        //        bullets[i+1].transform.rotation = firePos2.rotation;

        //        bullets[i].SetActive(true);
        //        break;
        //    }
        //}
        //GameObject bullet1 = GetBulletInPool();  // GameObject 대신 var로 쓸 수 있다.(var 는 어느 타입이느 다 호환)
        //GameObject bullet2 = GetBulletInPool();

        //if (bullet1 != null)
        //{
        //    bullet1.transform.position = firePos1.position;
        //    bullet1.transform.rotation = firePos1.rotation;
        //}
        //if(bullet2 != null)
        //{
        //    bullet2.transform.position = firePos2.position;
        //    bullet2.transform.rotation = firePos2.rotation;
        //}  // 강사님이 도와주셨지만 실패..(안계셔서 다음 기회에...)
        var _bullet1 = Instantiate(bullet, firePos1.position, firePos1.rotation);
        var _bullet2 = Instantiate(bullet, firePos2.position, firePos2.rotation);

        _bullet1.GetComponent<Missile>();
        _bullet2.GetComponent<Missile>();
    }

        //private GameObject GetBulletInPool()
        //{
        //    for (int i = 0; i < pooledAmount; i++)
        //    {
        //        if (bullets[i].activeInHierarchy == false)
        //        {
        //            return bullets[i];
        //        }
        //    }
        //    return null;
        //}


    void Update()
    {

        if (Time.time >= nextfire)
        {
            fire();
            nextfire = Time.time + fireRate;
        }
    }
}
