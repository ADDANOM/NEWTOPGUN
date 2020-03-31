using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class PlayerMove : MonoBehaviour
{
    private Vector2 trackpad;
    private Transform tr;
    private Transform Controller_Tr, Controller_Tr2;
    private Quaternion turn_angle;


    private Vector3 moveDirection;
    public float moveSpeed;
    public float moveSide;
    public float moveUp;
    public float speed = 50.0f;
    public SteamVR_Input_Sources leftHand;
    public SteamVR_Input_Sources rightHand;
    public SteamVR_Behaviour_Pose pose;
    public GameObject Player_Direction;



    void Start()
    {
        moveSpeed = 0.0f;
        tr = GetComponent<Transform>();
        Controller_Tr = transform.Find("[CameraRig]").transform.GetChild(1).transform.GetChild(1).GetComponent<Transform>();
        Controller_Tr2 = transform.Find("[CameraRig]").transform.GetChild(0).transform.GetChild(1).GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //moveDirection = Quaternion.AngleAxis(Player_Direction.transform.localRotation.eulerAngles.y, Vector3.up) * Vector3.forward;

        updateInput();

        GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * moveSpeed + transform.right * moveSide * speed + transform.up * moveUp * speed);


        //Debug.Log(Controller_Tr.eulerAngles.y); // left / right
        Debug.Log(Controller_Tr.eulerAngles.y + " ; " + Controller_Tr2.eulerAngles.y); // up / down
    }



    private void updateInput()
    {
        trackpad = SteamVR_Actions._default.speedUp.GetAxis(rightHand);
        moveSpeed = -1.0f * trackpad.x; // moving forward , backward

        if (Controller_Tr.eulerAngles.x >= 300 && Controller_Tr.eulerAngles.x <= 350 && Controller_Tr.eulerAngles.y < 105) // left
        {
            moveSide = -1.0f * Time.deltaTime;
        }
        else if (Controller_Tr.eulerAngles.x >= 10 && Controller_Tr.eulerAngles.x <= 50 && Controller_Tr.eulerAngles.y > 75) // right
        {
            moveSide = Time.deltaTime;
        }
        else
            moveSide = 0.0f;


        if (Controller_Tr.eulerAngles.z < 270) // up
        {
            moveUp = Time.deltaTime;
        }
        else if (Controller_Tr.eulerAngles.z > 295) // down
        {
            moveUp = -1.0f * Time.deltaTime;
        }
        else
            moveUp = 0.0f;


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
