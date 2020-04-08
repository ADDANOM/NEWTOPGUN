using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisItem : MonoBehaviour
{
    Vector3 pos;

    Transform tr;

    public GameObject Boom;
    public GameObject Lazer;
    public GameObject Missile;

    public ParticleSystem ExPlosion;

    void Start()
    {
        tr = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"tr = {tr.position}");
    }

    private void OnDisable()
    {
        pos = tr.position;

        PlayParticle();

        RandomItemSpawn();
    }

    void RandomItemSpawn()
    {
        float rand = Random.value;  // 0.0~1.0 이내의 랜덤값을 가져온다.

        if (rand <= 0.035f)  // 30% 확률로 아이템 소환
        {
            Debug.Log("SoWhan!!");

            RandomItemBox();
        }
        else
        {
            return;
        }
    }

    void RandomItemBox()
    {
        Debug.Log("Check");

        float rand = Random.value;

        if (rand < 0.09f)  // 10% Boom 아이템 소환
        {
            Debug.Log("Boom");
            Instantiate(Boom, pos, tr.rotation);
            
        }
        else if (rand < 0.4f)  //  30% 확률로 레이저 소환
        {
            Debug.Log("Lazer");
            Instantiate(Lazer, pos, tr.rotation);
           
        }
        else if (rand < 0.8f)  // 40% 확률
        {
            Debug.Log("Missile");
            Instantiate(Missile, pos, tr.rotation);
           
        }
        else
        {
            return;
        }
    }

    void PlayParticle()
    {
        Instantiate(ExPlosion, pos, tr.rotation);

        Destroy(ExPlosion,1.0f);
    }
}
