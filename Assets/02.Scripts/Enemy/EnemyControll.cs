using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    private ParticleSystem ExPlosion;
    public float moveSpeed = 10.0f;  // EnenmyMove 속도값.

    public float curHealth = 100.0f;
    public bool isAlive = true;

    private float timer;

    Transform EnemyPos;
    

    void Start()
    {
        //ExPlosion = transform.Find("E_Bomb_Effect").GetComponent<ParticleSystem>();  // 주석 풀어줘야함
        EnemyPos = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        EnenmyMove();

        if (this == false)
        {
            Debug.Log("Die??");

        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            curHealth = 0.0f;
            //ExPlosion.Play();  // 체력 0이 되면 실행하면된다. / 지금은 바로실행됨;  

            this.gameObject.SetActive(false);
            EnemyPos = other.transform;
            RandomItemSpawn();
            //Destroy(this);
            //Debug.Log("Destroy");
            
        }
    }

   void RandomItemSpawn()
    {
        float rand = Random.value;  // 0.0~1.0 이내의 랜덤값을 가져온다.

        if(rand <= 0.3f)  // 30% 확률로 아이템 소환
        {
            Debug.Log("SoWhan!!");

            // GameManager.instans.RandomItemBox();
        }
        else
        {
            return;
        }
    }

    void EnenmyMove()
    {
        float zMove = (moveSpeed * Time.deltaTime);
        transform.Translate(0, 0, zMove);
    }

}
