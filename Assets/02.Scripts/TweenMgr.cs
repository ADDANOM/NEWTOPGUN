using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenMgr : MonoBehaviour
{
    public GameObject Nomal_E;
    public GameObject Nomal2_E;
    public GameObject Nomal3_E;

    public Transform playerTr;

    void Start()
    {
        MoveNomal3_E();
        MoveNomal2_E();
        MoveNomal_E();
    }

   

    void MoveNomal_E()
    {
        Hashtable ht = new Hashtable();
        ht.Add("path", iTweenPath.GetPath("Path1"));
        ht.Add("time", 10.0f);  // 시간에 걸쳐 트랙을 돈다.
        ht.Add("easetype", iTween.EaseType.linear);
        ht.Add("orienttopath", true); // path 방향으로 자동으로 Rotation해줌
        ht.Add("looktarget", playerTr.position);
        ht.Add("looktime", 0.2f);

        iTween.MoveTo(Nomal_E, ht);  // 움직일 대상, Hashtable
    }

    void MoveNomal2_E()
    {
        Hashtable ht2 = new Hashtable();
        ht2.Add("path", iTweenPath.GetPath("Path2"));
        ht2.Add("time", 10.0f);  // 시간에 걸쳐 트랙을 돈다.
        ht2.Add("easetype", iTween.EaseType.linear);
        ht2.Add("orienttopath", true); // path 방향으로 자동으로 Rotation해줌
        ht2.Add("looktarget", playerTr.position);
        ht2.Add("looktime", 0.2f);

        iTween.MoveTo(Nomal2_E, ht2);  // 움직일 대상, Hashtable
    }

    void MoveNomal3_E()
    {
        Hashtable ht3 = new Hashtable();
        ht3.Add("path", iTweenPath.GetPath("Path3"));
        ht3.Add("time", 10.0f);  // 시간에 걸쳐 트랙을 돈다.
        ht3.Add("easetype", iTween.EaseType.linear);
        ht3.Add("orienttopath", true); // path 방향으로 자동으로 Rotation해줌
        ht3.Add("looktarget", playerTr.position);
        ht3.Add("looktime", 0.2f);

        iTween.MoveTo(Nomal3_E, ht3);  // 움직일 대상, Hashtable
    }



}
