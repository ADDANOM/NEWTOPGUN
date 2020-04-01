using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl_Check : MonoBehaviour
{
    static public bool check_ctrl;

    private float distance;
    private Transform tr, tr1;
    public GameObject other;

    private void Awake()
    {
        tr = GetComponent<Transform>();
        tr1 = other.GetComponent<Transform>();
    }

    private void Update()
    {
        Vector3 offset = tr.position - tr1.position;
        distance = offset.sqrMagnitude;

        if (distance < 0.01f)
        check_ctrl = true;
        else
        check_ctrl = false;

    }



    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.CompareTag("CONTROLLER"))
    //     {
    //         Debug.Log("true");
    //         check_ctrl = true;
    //     }
    // }

    // private void OnTriggerExit(Collider other)
    // {

    //     if (other.gameObject.CompareTag("CONTROLLER"))
    //     {
    //         Debug.Log("false");
    //         check_ctrl = false;
    //     }
    
    
    // }  ===>>>> 움직일 시 false가 나오는 오류로 트리거/콜리더 검출은 폐기 





}
