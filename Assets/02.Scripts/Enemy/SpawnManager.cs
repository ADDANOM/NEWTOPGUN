using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;
    public GameObject Enemy5;
    public GameObject Enemy6;
    public GameObject Enemy7;
    public GameObject Enemy8;

    //public List<GameObject> EnemyList = new List<GameObject>();

    public float spawnTime = 2.0f; // N초 간격으로 적을 생성
    public float spawnTotTime = 6.0f; //생성할 총 시간
    private float passedTime = 0.0f;

    public Transform[] points;  // 포인트를 배열로 담아준다.

    public int prevIndex = -1;

    private int ran;
    float Timer;

    int ranArray_0;
    int ranArray_1;

    void Start()
    {
        //InvokeRepeating("stage1", spawnTime, spawnTime);  // spawnTime만큼 대기후, spawnTime초 마다 Spawn을 호출한다.
        ran = 1;

    }

    void Update()
    {
        ranArray_0 = GameManager.ranArray[0];
        ranArray_1 = GameManager.ranArray[1];
        if (ranArray_0 == 9)
        ranArray_0 = 3;  // 범위초과 해소


        Timer += Time.deltaTime;

        StartCor();
    }

    void StartCor()
    {
        if (Timer >= 2.0f)  // 2초후
        {
            if (ran == 0 || ran == 1)
            {
                StartCoroutine("SpawnEnemy1");
            }
            if (ran == 2)
            {
                StartCoroutine("SpawnEnemy2");
            }
            if (ran == 3)
            {
                StartCoroutine("SpawnEnemy3");
            }
            if (ran == 4)
            {
                StartCoroutine("SpawnEnemy4");
            }
            if (ran == 5)
            {
                StartCoroutine("SpawnEnemy5");
            }
            if (ran == 6)
            {
                StartCoroutine("SpawnEnemy6");
            }
            if (ran == 7)
            {
                StartCoroutine("SpawnEnemy7");
            }
            if (ran == 8 || ran == 9)
            {
                StartCoroutine("SpawnEnemy8");
            }
            Timer = 0.0f;
        }

    }

    IEnumerator SpawnEnemy1()
    {
        if (passedTime <= spawnTotTime)  // spawnTotTime == n초보다 passedTime이 작을때까지 실행   /
        {
            int spawnPointIndex = ranArray_0;  // 스폰 포인트 배열값

            // while (spawnPointIndex == prevIndex)  // 똑같은 스폰 위치에 스폰이 안되도록 설정   
            // {
            //     spawnPointIndex = ranArray_1;  // 재배열
            // }  => 무한루프로 인해 제거함
            prevIndex = spawnPointIndex;

            Instantiate(Enemy1, points[spawnPointIndex].position, points[spawnPointIndex].rotation);

            ran = ranArray_1;
            yield return new WaitForSeconds(spawnTime);
        }
        passedTime = 0.0f;
    }

    IEnumerator SpawnEnemy2()
    {
        if (passedTime <= spawnTotTime)  // spawnTotTime == n초보다 passedTime이 작을때까지 실행  /
        {
            int spawnPointIndex = ranArray_0;  // 스폰 포인트 배열값

            prevIndex = spawnPointIndex;

            Instantiate(Enemy2, points[spawnPointIndex].position, points[spawnPointIndex].rotation);

            ran = ranArray_1;
            yield return new WaitForSeconds(spawnTime);
        }

        passedTime = 0.0f;
    }

    IEnumerator SpawnEnemy3()
    {
        if (passedTime <= spawnTotTime)  // spawnTotTime == n초보다 passedTime이 작을때까지 실행   /
        {
            int spawnPointIndex = ranArray_0;  // 스폰 포인트 배열값

            prevIndex = spawnPointIndex;

            Instantiate(Enemy3, points[spawnPointIndex].position, points[spawnPointIndex].rotation);

            ran = ranArray_1;
            yield return new WaitForSeconds(spawnTime);
        }
        passedTime = 0.0f;
    }

    IEnumerator SpawnEnemy4()
    {
        if (passedTime <= spawnTotTime)  // spawnTotTime == n초보다 passedTime이 작을때까지 실행   /
        {
            int spawnPointIndex = ranArray_0;  // 스폰 포인트 배열값

            prevIndex = spawnPointIndex;

            Instantiate(Enemy4, points[spawnPointIndex].position, points[spawnPointIndex].rotation);

            ran = ranArray_1;
            yield return new WaitForSeconds(spawnTime);
        }
        passedTime = 0.0f;
    }

    IEnumerator SpawnEnemy5()
    {
        if (passedTime <= spawnTotTime)  // spawnTotTime == n초보다 passedTime이 작을때까지 실행   /
        {
            int spawnPointIndex = ranArray_0;  // 스폰 포인트 배열값

            prevIndex = spawnPointIndex;

            Instantiate(Enemy5, points[spawnPointIndex].position, points[spawnPointIndex].rotation);

            ran = ranArray_1;
            yield return new WaitForSeconds(spawnTime);
        }
        passedTime = 0.0f;
    }

    IEnumerator SpawnEnemy6()
    {
        if (passedTime <= spawnTotTime)  // spawnTotTime == n초보다 passedTime이 작을때까지 실행   /
        {
            int spawnPointIndex = ranArray_0;  // 스폰 포인트 배열값

            prevIndex = spawnPointIndex;

            Instantiate(Enemy6, points[spawnPointIndex].position, points[spawnPointIndex].rotation);

            ran = ranArray_1;
            yield return new WaitForSeconds(spawnTime);
        }
        passedTime = 0.0f;
    }

    IEnumerator SpawnEnemy7()
    {
        if (passedTime <= spawnTotTime)  // spawnTotTime == n초보다 passedTime이 작을때까지 실행   /
        {
            int spawnPointIndex = ranArray_0;  // 스폰 포인트 배열값

            prevIndex = spawnPointIndex;

            Instantiate(Enemy7, points[spawnPointIndex].position, points[spawnPointIndex].rotation);

            ran = ranArray_1;
            yield return new WaitForSeconds(spawnTime);
        }
        passedTime = 0.0f;
    }

    IEnumerator SpawnEnemy8()
    {
        if (passedTime <= spawnTotTime)  // spawnTotTime == n초보다 passedTime이 작을때까지 실행   /
        {
            int spawnPointIndex = ranArray_0;  // 스폰 포인트 배열값

            prevIndex = spawnPointIndex;

            Instantiate(Enemy8, points[spawnPointIndex].position, points[spawnPointIndex].rotation);

            ran = ranArray_1;
            yield return new WaitForSeconds(spawnTime);
        }
        passedTime = 0.0f;
    }

}


