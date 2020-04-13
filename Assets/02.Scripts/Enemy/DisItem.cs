using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DisItem : MonoBehaviourPunCallbacks
{
    Vector3 pos;

    Transform tr;

    public ParticleSystem ExPlosion;

    int ranArray_0;
    int ranArray_1;

    int random;
    int random2;

    void Start()
    {
        tr = GetComponent<Transform>();
        random = Random.Range(1, 11);
        random2 = Random.Range(1, 11);
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
        if (random <= 2)  // 30% 확률로 아이템 소환
        {
            RandomItemBox();
        }

    }

    void RandomItemBox()
    {
        if (random2 <= 3)  // 30% Boom 아이템 소환
        {
            GameObject BoomBox = PhotonNetwork.InstantiateSceneObject("BoomBox", pos, tr.rotation) as GameObject;

        }
        else if (random2 <= 7)  //  40% 확률로 힐 소환
        {
            GameObject HealBox = PhotonNetwork.InstantiateSceneObject("HealBox", pos, tr.rotation) as GameObject;

        }
        else  //  40% 확률로 서브미사일 소환
        {
            GameObject MisileBox = PhotonNetwork.InstantiateSceneObject("MisileBox", pos, tr.rotation) as GameObject;
        }
    }

    void PlayParticle()
    {
        Instantiate(ExPlosion, pos, tr.rotation);

        Destroy(ExPlosion, 1.0f);
    }
}
