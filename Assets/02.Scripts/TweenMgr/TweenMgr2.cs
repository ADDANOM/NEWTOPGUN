using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenMgr2 : MonoBehaviour
{
    
    public GameObject Nomal2_E;
    

    //public Transform playerTr;

    void Start()
    {

        
        MoveNomal2_E();
        
    }



    void MoveNomal2_E()
    {
        Hashtable ht2 = new Hashtable();
        ht2.Add("path", iTweenPath.GetPath("trackb"));
        ht2.Add("time", 10.0f);  // 시간에 걸쳐 트랙을 돈다.
        ht2.Add("easetype", iTween.EaseType.linear);
        ht2.Add("orienttopath", true); // path 방향으로 자동으로 Rotation해줌
        //ht2.Add("looktarget", playerTr.position);
        ht2.Add("looktime", 0.2f);

        iTween.MoveTo(Nomal2_E, ht2);  // 움직일 대상, Hashtable
    }




}
