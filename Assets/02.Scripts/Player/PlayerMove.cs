using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
//using Sym = Sym4D.Sym4DEmulator;
using Photon.Pun;


public class PlayerMove : MonoBehaviourPunCallbacks, IPunObservable
{
    private Vector2 trackpad;
    private Transform tr;
    private Rigidbody rg;

    private Animator anim;
    private float v, h;
    private ParticleSystem Booster_1;
    private ParticleSystem Booster_2;
    private ParticleSystem Shot;



    // 컨트롤러 체크
    private Transform Controller_Tr, Controller_Tr2;
    static public bool check_ctrl;
    private float distance;
    private Transform check_tr_1, check_tr_2;
    public GameObject check_ctrl_left;
    public GameObject check_ctrl_right;

    //이동
    float forwardSpeed;
    float moveSide;
    float moveUp;
    bool moveForward;
    bool moveBehind;
    float _go;
    public float speed = 50.0f;
    public SteamVR_Input_Sources leftHand;
    public SteamVR_Input_Sources rightHand;

    //공격
    public bool onFire = false;
    public bool onBomb = false;
    PlayerShot playerShot;
    PlayerHealth playerHealth;
    float health;


    //심포디
    public int xPort; //좌석장비의 통신 포트
    public int wPort; //바람장비의 통신 포트
    private WaitForSeconds ws = new WaitForSeconds(1.5f);
    float prevJoyX, prevJoyY;
    float currJoyX, currJoyY;

    private AudioSource myAudio;
    public AudioClip P_attack;
    private FollowCam followCam;

    void Awake()
    {
        v = 0.0f;
        h = 0.0f;
        forwardSpeed = 0.0f;
        tr = GetComponent<Transform>();
        rg = GetComponent<Rigidbody>();

        anim = transform.Find("FighterInterceptor").GetComponent<Animator>();

        Booster_1 = transform.Find("FighterInterceptor").transform.Find("Booster_1").GetComponent<ParticleSystem>();
        Booster_2 = transform.Find("FighterInterceptor").transform.Find("Booster_2").GetComponent<ParticleSystem>();

        Shot = transform.Find("FighterInterceptor").transform.Find("Fire_Effect").GetComponent<ParticleSystem>();
        Controller_Tr = transform.Find("[CameraRig]").transform.GetChild(0).transform.GetChild(1).GetComponent<Transform>();
        Controller_Tr2 = transform.Find("[CameraRig]").transform.GetChild(1).transform.GetChild(1).GetComponent<Transform>();

        check_tr_1 = check_ctrl_left.GetComponent<Transform>();
        check_tr_2 = check_ctrl_right.GetComponent<Transform>();

        playerShot = GetComponent<PlayerShot>();
        playerHealth = GetComponent<PlayerHealth>();

        // xPort = Sym.Sym4D_X_Find();
        // wPort = Sym.Sym4D_W_Find();

        myAudio = GetComponent<AudioSource>();

        if (photonView.IsMine)
        {
            followCam = Camera.main.GetComponent<FollowCam>();
            followCam.target = tr;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            ctrl();
            updateInput();
            flight_anim();
            shot();
            photonView.RPC("shot", RpcTarget.Others);
        }
        else
        {
            Vector3 pos = Vector3.Lerp(tr.position, currPos, Time.deltaTime * 5.0f);
            Quaternion rot = Quaternion.Slerp(tr.rotation, currRot, Time.deltaTime * 5.0f);

            tr.position = pos;
            tr.rotation = rot;

            if (onFire_other)
            {
                myAudio.clip = P_attack;
                myAudio.Play();
                if (!Shot.isPlaying)
                {
                    Shot.Play();
                }
                playerShot.shotEnable();
            }
            else
            {
                if (Shot.isPlaying)
                {
                    Shot.Stop();
                }
                playerShot.shotDisable();
            }

            if (onBomb_other)
            {
                playerShot.doBomb();
            }

        }
    }

    [PunRPC]
    private void shot()
    {
        onFire = SteamVR_Actions._default.InteractUI.GetState(leftHand);
        onBomb = SteamVR_Actions._default.InteractUI.GetState(rightHand);
        health = playerHealth.curPlayerHealth;
                

        if (onFire)
        {
            myAudio.clip = P_attack;
            myAudio.Play();
            if (!Shot.isPlaying)
            {
                Shot.Play();

            }
            playerShot.shotEnable();
        }
        else
        {
            if (Shot.isPlaying)
            {
                Shot.Stop();
            }
            playerShot.shotDisable();
        }

        if (onBomb)
        {
            if (photonView.IsMine)
            playerShot.doBomb();
        }

    }



    private void ctrl() // 컨트롤러를 제대로 쥐었는가 판단 
    {
        Vector3 offset = check_tr_1.position - check_tr_2.position;
        distance = offset.sqrMagnitude;

        if (distance < 0.01f && distance != 0.0f)
            check_ctrl = true;
        else
            check_ctrl = false;

    }


    private void updateInput()
    {
        moveBehind = SteamVR_Actions._default.GrabGrip.GetState(rightHand);
        moveForward = SteamVR_Actions._default.GrabGrip.GetState(leftHand);

        if (moveForward & !moveBehind)
            _go = 1.0f;
        else if (moveBehind & !moveForward)
            _go = -1.0f;
        else
            _go = 0.0f;


        //trackpad = SteamVR_Actions._default.speedUp.GetAxis(rightHand);
        forwardSpeed = 1.0f * _go; // moving forward , backward

        var main1 = Booster_1.main;
        var main2 = Booster_2.main;
        if (forwardSpeed < 0)
        {
            main1.startColor = new Color(1.0f, 0.51f, 0.31f, 0.0f);
            main2.startColor = new Color(1.0f, 0.51f, 0.31f, 0.0f);
        }
        else if (forwardSpeed == 0)
        {
            main1.startColor = new Color(1.0f, 0.51f, 0.31f, 0.5f);
            main2.startColor = new Color(1.0f, 0.51f, 0.31f, 0.5f);
        }
        else
        {
            main1.startColor = new Color(0.04f, 0.26f, 1.00f, 0.5f);
            main2.startColor = new Color(0.04f, 0.26f, 1.00f, 0.5f);
        }

        if (Controller_Tr.eulerAngles.x >= 300 && Controller_Tr.eulerAngles.x <= 350 && Controller_Tr.eulerAngles.y < 105) // left
        {
            if (v >= -0.98f)
                v -= 0.02f;
            moveSide = -1.0f * Time.deltaTime;


        }
        else if (Controller_Tr.eulerAngles.x >= 10 && Controller_Tr.eulerAngles.x <= 50 && Controller_Tr.eulerAngles.y > 75) // right
        {
            if (v <= 0.98f)
                v += 0.02f;
            moveSide = Time.deltaTime;


        }
        else
        {
            moveSide = 0.0f;
            if (v > 0.0f)
                v -= 0.02f;
            else if (v < 0.0f)
                v += 0.02f;


        }



        if (Controller_Tr.eulerAngles.z < 270) // up
        {
            if (h <= 0.98f)
                h += 0.02f;
            moveUp = Time.deltaTime;


        }
        else if (Controller_Tr.eulerAngles.z > 295) // down
        {
            if (h >= -0.98f)
                h -= 0.02f;
            moveUp = -1.0f * Time.deltaTime;


        }
        else
        {
            moveUp = 0.0f;
            if (h > 0.0f)
                h -= 0.02f;
            else if (h < 0.0f)
                h += 0.02f;
        }


    }
    // IEnumerator ChangeRollNPitch()
    // {

    //     yield return new WaitForSeconds(0.1f);

    //     //Sym4D-X100 COM Port Open  및 컨텐츠 시작을 장치에 전달
    //     Sym.Sym4D_X_StartContents(xPort);
    //     yield return new WaitForSeconds(0.1f);

    //     Sym.Sym4D_X_SendMosionData((int)(-currJoyX * 100), (int)(currJoyY * 100));

    //     yield return new WaitForSeconds(0.1f);
    // }

    // void OnDestroy()
    // {
    //     Sym.Sym4D_X_EndContents();
    // }

    private void flight_anim()
    {
        if (check_ctrl)
        {
            rg.MovePosition(transform.position + transform.forward * forwardSpeed + transform.right * moveSide * speed + transform.up * moveUp * speed);
            anim.SetFloat("Player_Side", v);
            anim.SetFloat("Player_Up", h);
            //     //심포디
            //     currJoyX = v;
            //     currJoyY = h;
            //     Debug.Log($"X={(int)(-currJoyX * 100)} / Y={(int)(currJoyY * 100)}");

            //     if (currJoyX != prevJoyX)
            //     {
            //         //Change Roll
            //         prevJoyX = currJoyX;
            //         StartCoroutine(ChangeRollNPitch());
            //     }

            //     if (currJoyY != prevJoyY)
            //     {
            //         //Change Pitch
            //         prevJoyY = currJoyY;
            //         StartCoroutine(ChangeRollNPitch());
            //     }
            // }
        }
    }

    private Vector3 currPos;
    private Quaternion currRot;

    bool onFire_other;
    bool onBomb_other;
    public float health_other;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(tr.position);
            stream.SendNext(tr.rotation);
            stream.SendNext(onFire);
            stream.SendNext(onBomb);
            stream.SendNext(health);
        }
        else
        {
            currPos = (Vector3)stream.ReceiveNext();
            currRot = (Quaternion)stream.ReceiveNext();
            onFire_other = (bool)stream.ReceiveNext();
            onBomb_other = (bool)stream.ReceiveNext();
            health_other = (float)stream.ReceiveNext();
        }

    }


}
