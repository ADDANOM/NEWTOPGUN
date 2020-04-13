using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sym = Sym4D.Sym4DEmulator;
using Photon.Pun;

public class Sym4DController2 : MonoBehaviourPunCallbacks
{
    public int xPort; //좌석장비의 통신 포트
    public int wPort; //바람장비의 통신 포트


    private WaitForSeconds ws = new WaitForSeconds(1.5f);

    public void OnInit()
    {
        StartCoroutine(Init());
    }

    //포트 번호 초기화 및 기본 테스트
    IEnumerator Init()
    {
        print("Init");
        //포트번호 설정
        xPort = Sym.Sym4D_X_Find();
        wPort = Sym.Sym4D_W_Find();

        yield return ws;
        Debug.Log($"X Port={xPort} W Port={wPort}");

        //Sym4D-X100 COM Port Open  및 컨텐츠 시작을 장치에 전달
        Sym.Sym4D_X_StartContents(xPort); // 세션 오픈
        yield return ws;

        Sym.Sym4D_X_New_SendVibration(100);
        yield return ws;
        //Roll, Pitch 최대허용 각도(0 ~ 100) : 0도 ~ 10도  // Roll 옆, Pitch 앞뒤
        Sym.Sym4D_X_SetConfig(100, 100);
        yield return ws;

        // //Sym4D-X100에 모션 데이터 전달(-100 ~ +100)
        // Sym.Sym4D_X_SendMosionData(0, 0);
        // yield return ws;

        // Sym.Sym4D_X_SendMosionData(100, 100);
        // yield return ws;

        // Sym.Sym4D_X_SendMosionData(-100, -100);
        // yield return ws;

        // Sym.Sym4D_X_SendMosionData(100, -100);
        // yield return ws;

        // Sym.Sym4D_X_SendMosionData(-100, 100);
        // yield return ws;

        // Sym.Sym4D_X_SendMosionData(0, 0);
        // yield return ws;

        Sym.Sym4D_X_EndContents(); // 세션 클로즈
        yield return ws;


        // //Wind 테스트
        // Sym.Sym4D_W_StartContents(wPort);
        // yield return ws;

        // Sym.Sym4D_W_SendMosionData(0);
        // yield return new WaitForSeconds(1);

        // Sym.Sym4D_W_SendMosionData(50);
        // yield return new WaitForSeconds(5);

        // Sym.Sym4D_W_SendMosionData(100);
        // yield return new WaitForSeconds(5);

        // Sym.Sym4D_W_SendMosionData(50);
        // yield return new WaitForSeconds(5);

        // Sym.Sym4D_W_SendMosionData(0);
        // yield return ws;

        // Sym.Sym4D_W_EndContents();
    }

    float prevJoyX, prevJoyY;
    float currJoyX, currJoyY;
    bool isFinished = false;

    PlayerMove playerMove;
    Transform Controller_Tr;

    private void Start()
    {
        Controller_Tr = transform.parent.transform.Find("[CameraRig]").transform.GetChild(0).transform.GetChild(1).GetComponent<Transform>();
        playerMove = transform.parent.GetComponent<PlayerMove>();
        OnInit();
    }

    void Update()
    {
        if (!photonView.IsMine)
            return;

        currJoyX = playerMove.v;
        currJoyY = playerMove.h;
        if (currJoyX != prevJoyX && PlayerMove.check_ctrl)
        {
            if (Controller_Tr.eulerAngles.x >= 300 && Controller_Tr.eulerAngles.x <= 350 && Controller_Tr.eulerAngles.y < 105) // left
            {
                prevJoyX = currJoyX;
                StartCoroutine(ChangeRollNPitch());
            }
            else if (Controller_Tr.eulerAngles.x >= 10 && Controller_Tr.eulerAngles.x <= 50 && Controller_Tr.eulerAngles.y > 75) // right
            {
                prevJoyX = currJoyX;
                StartCoroutine(ChangeRollNPitch());
            }
            else
            {
                currJoyX = 0;
                prevJoyX = currJoyX;
                StartCoroutine(ChangeRollNPitch());
            }


        }

        if (currJoyY != prevJoyY && PlayerMove.check_ctrl)
        {

            if (Controller_Tr.eulerAngles.z < 270) // up
            {
                prevJoyY = currJoyY;
                StartCoroutine(ChangeRollNPitch());
            }
        }
        else if (Controller_Tr.eulerAngles.z > 295) // down
        {
            if (Controller_Tr.eulerAngles.z < 270) // up
            {
                prevJoyY = currJoyY;
                StartCoroutine(ChangeRollNPitch());
            }

        }
        else
        {
            currJoyY = 0;
            prevJoyY = currJoyY;
            StartCoroutine(ChangeRollNPitch());
        }

    }

    IEnumerator ChangeRollNPitch()
    {
        yield return new WaitForSeconds(0.1f);

        //Sym4D-X100 COM Port Open  및 컨텐츠 시작을 장치에 전달
        Sym.Sym4D_X_StartContents(xPort);
        yield return new WaitForSeconds(0.1f);

        Sym.Sym4D_X_SendMosionData((int)(-currJoyX * 50), (int)(-currJoyY * 50));
        Debug.Log((int)(-currJoyX * 100) + " and " + (int)(-currJoyY * 100));

        yield return new WaitForSeconds(0.1f);
    }

    void OnDestroy()
    {
        Sym.Sym4D_X_EndContents();
    }
}
