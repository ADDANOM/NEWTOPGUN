﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharactor : MonoBehaviour
{
    bool bTurnLeft = false;
    bool bTurnRight = false;
    private Quaternion turn = Quaternion.identity;
    // 정의
    public static int charactorNum = 0;
    int value = 0;

    AudioSource mysource;



    void Start()
    {
        turn.eulerAngles = new Vector3(0, value, 0);  // 각도 초기화

        mysource = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        SelectChar();
    }

    public void SelectChar()
    {
        if (bTurnLeft)
        {
            charactorNum++;
            if (charactorNum == 4)
                charactorNum = 0;

            value -= 90;

            bTurnLeft = false;
        }
        if (bTurnRight)
        {
            charactorNum--;
            if (charactorNum == -1)
                charactorNum = 3;

            value += 90;

            bTurnRight = false;
        }
        turn.eulerAngles = new Vector3(0, value, 0);  // 각을 설정

        transform.rotation = Quaternion.Slerp(transform.rotation, turn, Time.deltaTime * 5.0f);  //
    }

    public void turnLeft()  // 다른 버튼 누를 때 까지 설정
    {
        bTurnLeft = true;
        bTurnRight = false;

        mysource.Play();
    }

    public void turnRight()
    {
        bTurnRight = true;
        bTurnLeft = false;

        mysource.Play();
    }
}
