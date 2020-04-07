﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Transform targetTr;  // 플레이어 타겟위치

    public float minDist = 50.0f;  // 사정거리
    private float currDist = 0;  // 두 오브젝트의 거리
    public float rotDamping = 10.0f;  // 회전각도에 더해줄값 = 부드럽게
    public float moveSpeed = 50.0f;

    //private GameObject bullet;
    private Transform missileTr;
    private bool isPassed = false;  // 지나갔는지 여부

    void Start()
    {
        Destroy(this.gameObject, 10.0f);
        //bullet = GetComponent<GameObject>();
        missileTr = transform;

        int targetSelect = Random.Range(0, 2);
        if (targetSelect == 0)
        {
            targetTr = GameObject.Find("Player").transform;
        }
        else
        {
            targetTr = GameObject.Find("newPlayer").transform;
        }
    }

    private void OnEnable()
    {
        GameManager.onBulletClear += BulletClear;
    }
    private void OnDisable()
    {
        GameManager.onBulletClear -= BulletClear;

    }

    void Update()
    {
        currDist = Vector3.Distance(targetTr.position, missileTr.position);

        if (!isPassed && currDist > minDist)  // 사정거리 밖
        {
            isPassed = false;
            Quaternion rot = Quaternion.LookRotation(targetTr.position - missileTr.position);  // ??
            missileTr.rotation = Quaternion.Slerp(missileTr.rotation, rot, Time.deltaTime * rotDamping);  // 미사일의 회전값(부드럽게)
            //Debug.Log("Isn't Pass");
        }
        if (currDist < minDist)  // 사정거리에 들어오면 지나간걸로 판단 그냥 직진한다.
        {
            isPassed = true;
            //Debug.Log("IsPassed");
        }
        missileTr.Translate(Vector3.forward * Time.deltaTime * moveSpeed);  // 직진
    }

    void BulletClear()
    {
        Destroy(this.gameObject);

    }

}
