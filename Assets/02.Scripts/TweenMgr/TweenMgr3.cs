using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenMgr3 : MonoBehaviour
{
    public GameObject Nomal3_E;

    //public Transform playerTr;

    void Start()
    {

        MoveNomal3_E();
       
       
    }




    void MoveNomal3_E()
    {
        Hashtable ht3 = new Hashtable();
        ht3.Add("path", iTweenPath.GetPath("trackc"));
        ht3.Add("time", 10.0f);  // 시간에 걸쳐 트랙을 돈다.
        ht3.Add("easetype", iTween.EaseType.linear);
        ht3.Add("orienttopath", true); // path 방향으로 자동으로 Rotation해줌
        //ht3.Add("looktarget", playerTr.position);
        ht3.Add("looktime", 0.2f);

        iTween.MoveTo(Nomal3_E, ht3);  // 움직일 대상, Hashtable
    }



}
