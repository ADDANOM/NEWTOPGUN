using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;


    public float spawnTime = 2.0f; // N초 간격으로 적을 생성
    public float spawnTotTime = 5.0f; //생성할 총 시간
    private float passedTime = 0.0f;

    public Transform[] points;  // 포인트를 배열로 담아준다.

    public int prevIndex = -1;


    void Start()
    {
        //timer = Time.time;

        //InvokeRepeating("stage1", spawnTime, spawnTime);  // spawnTime만큼 대기후, spawnTime초 마다 Spawn을 호출한다.
        
        StartCoroutine(CreateEnemy1());
        
    }



    IEnumerator CreateEnemy1()
    {
        while (passedTime <= spawnTotTime)  // spawnTotTime == 5초보다 passedTime이 작을때까지 실행
        {
            yield return new WaitForSeconds(spawnTime);

            int spawnPointIndex = Random.Range(0, points.Length);  // 스폰 포인트 배열값

            while (spawnPointIndex == prevIndex )  // 똑같은 스폰 위치에 스폰이 안되도록 설정
            {
                spawnPointIndex = Random.Range(0, points.Length);
            }
            prevIndex = spawnPointIndex;

            Instantiate(enemy1, points[spawnPointIndex].position, points[spawnPointIndex].rotation);

            passedTime = Time.time;
        }
        
        //Debug.Log("Finish");

        yield return StartCoroutine(CreateEnemy2());
    }

    IEnumerator CreateEnemy2()
    {
        //Debug.Log("Loding");
        while (passedTime <= 18.0f)
        {
            //Debug.Log("Restart");
            yield return new WaitForSeconds(spawnTime);

            int spawnPointIndex = Random.Range(0, points.Length);  // 스폰 포인트 배열값

            while (spawnPointIndex == prevIndex)  // 똑같은 스폰 위치에 스폰이 안되도록 설정
            {
                spawnPointIndex = Random.Range(0, points.Length);
            }
            prevIndex = spawnPointIndex;

            Instantiate(enemy2, points[spawnPointIndex].position, points[spawnPointIndex].rotation);

            passedTime = Time.time;
        }
    }



    void Update()
    {
        
    }
}
