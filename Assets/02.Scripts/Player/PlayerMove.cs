using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class PlayerMove : MonoBehaviour
{
    private Vector2 trackpad;
    private Transform tr;
    private Rigidbody rg;

    private Animator anim;
    private float v, h;
    private ParticleSystem Booster_1;
    private ParticleSystem Booster_2;
    private ParticleSystem Bomb;
    private ParticleSystem Shot;
    private float nextBomb = 0.0f;
    private float bombRate = 3.0f;

    private Transform Controller_Tr, Controller_Tr2;

    static public bool check_ctrl;

    private float distance;
    private Transform check_tr_1, check_tr_2;
    public GameObject check_ctrl_left;
    public GameObject check_ctrl_right;

    float forwardSpeed;
    float moveSide;
    float moveUp;
    bool moveForward;
    bool moveBehind;
    float _go;
    public float speed = 50.0f;
    public SteamVR_Input_Sources leftHand;
    public SteamVR_Input_Sources rightHand;

    public bool onFire = false;
    public bool onBomb = false;
    public GameObject mainshotPos;
    public GameObject subshotPos_a;
    public GameObject subshotPos_b;



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
        Bomb = transform.Find("Bomb_Effect").GetComponent<ParticleSystem>();
        Shot = transform.Find("FighterInterceptor").transform.Find("Fire_Effect").GetComponent<ParticleSystem>();
        Controller_Tr = transform.Find("[CameraRig]").transform.GetChild(1).transform.GetChild(1).GetComponent<Transform>();
        Controller_Tr2 = transform.Find("[CameraRig]").transform.GetChild(0).transform.GetChild(1).GetComponent<Transform>();

        check_tr_1 = check_ctrl_left.GetComponent<Transform>();
        check_tr_2 = check_ctrl_right.GetComponent<Transform>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ctrl();

        updateInput();

        if (check_ctrl == true)
            rg.MovePosition(transform.position + transform.forward * forwardSpeed + transform.right * moveSide * speed + transform.up * moveUp * speed);

        shot();

        //Debug.Log(Controller_Tr.eulerAngles.y); // left / right
        //Debug.Log(Controller_Tr.eulerAngles.y + " ; " + Controller_Tr2.eulerAngles.y); // up / down


    }

    private void shot()
    {
        onFire = SteamVR_Actions._default.InteractUI.GetState(rightHand);
        onBomb = SteamVR_Actions._default.InteractUI.GetState(leftHand);

        if (onFire)
        {
            if (!Shot.isPlaying)
            {
                Shot.Play();
            }
            mainshotPos.GetComponent<PlayerFire>().enabled = true;
            subshotPos_a.GetComponent<PlayerSubFire>().enabled = true;
            subshotPos_b.GetComponent<PlayerSubFire>().enabled = true;
        }
        else
        {
            if (Shot.isPlaying)
            {
                Shot.Stop();
            }
            mainshotPos.GetComponent<PlayerFire>().enabled = false;
            subshotPos_a.GetComponent<PlayerSubFire>().enabled = false;
            subshotPos_b.GetComponent<PlayerSubFire>().enabled = false;
        }
        if (onBomb && !Bomb.isPlaying)
        {
            if (Time.time >= nextBomb)
            {
                Bomb.Play();
                nextBomb = Time.time + bombRate;
            }
        }

    }

    private void ctrl() // 컨트롤러를 제대로 쥐었는가 판단 
    {
        Vector3 offset = check_tr_1.position - check_tr_2.position;
        distance = offset.sqrMagnitude;

        if (distance < 0.01f)
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
        forwardSpeed = -1.0f * _go; // moving forward , backward

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


        anim.SetFloat("Player_Side", v);
        anim.SetFloat("Player_Up", h);

        // if (check_ctrl == false)
        // {
        //     anim.SetFloat("Player_Side", 0);
        //     anim.SetFloat("Player_Up", 0);
        // }



        // if (Controller_Tr.eulerAngles.y < 75) //..
        // {
        //     // moveUp = Time.deltaTime;
        //     Debug.Log("small left");
        //     turn_angle = Quaternion.Euler(0, -10f, 0);
        //     transform.rotation = Quaternion.RotateTowards(transform.rotation, turn_angle, Time.deltaTime * 40f);
        // }
        // else if (Controller_Tr.eulerAngles.y > 105) //..
        // {
        //     // moveUp = -1.0f *Time.deltaTime;
        //     Debug.Log("small right");
        //     turn_angle = Quaternion.Euler(0, 10f, 0);
        //     transform.rotation = Quaternion.RotateTowards(transform.rotation, turn_angle, Time.deltaTime * 40f);

        // }
        // else
        // {
        //     turn_angle = Quaternion.Euler(0, 0, 0);
        //     transform.rotation = Quaternion.RotateTowards(transform.rotation, turn_angle, Time.deltaTime * 40f);
        // }

    }



}
