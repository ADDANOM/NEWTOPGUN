using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Transform targetTr;  // 플레이어 타겟위치
    
    public float minDist = 20.0f;  // 사정거리
    private float currDist = 0;  // 두 오브젝트의 거리
    public float rotDamping = 10.0f;  // 회전각도에 더해줄값 = 부드럽게
    public float moveSpeed = 20.0f;

    private Transform missileTr;
    private bool isPassed = false;  // 지나갔는지 여부

    //private GameObject FaObj;

    // Start is called before the first frame update
    void Start()
    {
        missileTr = transform;
        targetTr = GameObject.FindGameObjectWithTag("Player").transform;

        //FaObj = GameObject.FindGameObjectWithTag("ENEMY");
    }

    void LateUpdate()
    {
        currDist = Vector3.Distance(targetTr.position, missileTr.position);

        if (!isPassed && currDist > minDist)  // 사정거리 밖
        {
            Quaternion rot = Quaternion.LookRotation(targetTr.position - missileTr.position);  // ??
            missileTr.rotation = Quaternion.Slerp(missileTr.rotation, rot, Time.deltaTime * rotDamping);  // 미사일의 회전값(부드럽게)
        }
        else  // 사정거리에 들어오면 지나간걸로 판단 그냥 직진한다.
        {
            isPassed = true;
            StartCoroutine(DestroyBullet());

        }
        missileTr.Translate(Vector3.forward * Time.deltaTime * moveSpeed);  // 직진
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
        //Destroy(FaObj, 1.0f);

    }
}
