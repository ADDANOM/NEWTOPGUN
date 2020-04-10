using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisItem : MonoBehaviour
{
    Vector3 pos;

    Transform tr;

    public GameObject Boom;
    public GameObject Heal;
    public GameObject Missile;

    public ParticleSystem ExPlosion;

    int ranArray_0;
    int ranArray_1;

    void Start()
    {
        tr = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        ranArray_0 = GameManager.ranArray[1];
        ranArray_1 = GameManager.ranArray[2];
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
        int rand = ranArray_0;  // 0.0~1.0 이내의 랜덤값을 가져온다.

        if (rand <= 1)  // 10% 확률로 아이템 소환
        {
            RandomItemBox();
        }

    }

    void RandomItemBox()
    {
        Debug.Log("Check");


        if (ranArray_1 < 2)  // 20% Boom 아이템 소환
        {
            Instantiate(Boom, pos, tr.rotation);

        }
        else if (ranArray_1 < 6)  //  40% 확률로 힐 소환
        {
            Instantiate(Heal, pos, tr.rotation);

        }
        else  //  40% 확률로 서브미사일 소환
        {
            Instantiate(Missile, pos, tr.rotation);
        }
    }

    void PlayParticle()
    {
        Instantiate(ExPlosion, pos, tr.rotation);

        Destroy(ExPlosion, 1.0f);
    }
}
