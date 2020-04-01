using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] points;  // 포인트를 배열로 담아준다.
    public GameObject enemy;

    public float creaTime = 3.0f; // 5초마다 생성

    // Start is called before the first frame update
    void Start()
    {
        points = GameObject.Find("SPAWNPOINT").GetComponentsInChildren<Transform>();  // 시작과 함께 points에 배열에 담기
        StartCoroutine(this.CreatEnemy());
    }

    IEnumerator CreatEnemy()
    {
        while (true)
        {
            int idx = Random.Range(1, points.Length);
            Instantiate(enemy, points[idx].position, Quaternion.identity);

            yield return new WaitForSeconds(creaTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
