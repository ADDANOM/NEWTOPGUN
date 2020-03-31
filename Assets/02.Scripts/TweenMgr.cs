using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenMgr : MonoBehaviour
{
    public GameObject fa1, fa2, fa3;
    void Start()
    {
        //var playerTr = GameObject.Find("Player").transform;

        Hashtable ht = new Hashtable();
        ht.Add("path", iTweenPath.GetPath("Path1"));
        ht.Add("time", 10.0f);  // 시간에 걸쳐 트랙을 돈다.
        ht.Add("easetype", iTween.EaseType.linear);
        //ht.Add("orienttopath", true); // path 방향으로 자동으로 Rotation해줌
        //ht.Add("looktarget", playerTr.position);
        ht.Add("looktime", 0.2f);

        iTween.MoveTo(fa1, ht);  // 움직일 대상, Hashtable
        iTween.MoveTo(fa2, ht);
        iTween.MoveTo(fa3, ht);
    }

    //void MoveUfo2()
    //{
    //    //Uof2 Move By
    //    Hashtable ht = new Hashtable();
    //    ht.Add("y", 20.0f);
    //    ht.Add("time", 2.0f);
    //    //ht.Add("delay", 5.0f);   // Ufo1이 끝나고 콜백으로 불러주기 떄문에 딜레이가 필요없다.
    //    ht.Add("easetype", iTween.EaseType.easeOutElastic);
    //    ht.Add("oncompletetarget", this.gameObject);
    //    ht.Add("oncomplete", "MoveUfo3");

    //    iTween.MoveBy(fa2, ht);
    //}

    //void MoveUfo3()
    //{
    //    //UFO3 Move From
    //    Hashtable ht1 = new Hashtable();
    //    ht1.Add("y", 50.0f);
    //    ht1.Add("time", 5.0f);
    //    //ht1.Add("delay", 7.0f);
    //    ht1.Add("easetype", iTween.EaseType.easeOutElastic);

    //    iTween.MoveFrom(fa3, ht1);
    //}

    // Update is called once per frame
    void Update()
    {

    }
}
