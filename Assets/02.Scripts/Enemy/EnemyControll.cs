using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    private ParticleSystem ExPlosion;
    public float moveSpeed = 10.0f;  // EnenmyMove 속도값.

    public float curHealth = 100.0f;
    public bool isAlive = true;

    private float timer = 0;
    void Start()
    {
        ExPlosion = transform.Find("E_Bomb_Effect").GetComponent<ParticleSystem>();

        timer += Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        EnenmyMove();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Destroy");
            ExPlosion.Play();  // 체력 0이 되면 실행하면된다. / 지금은 바로실행됨;   
            timer++;
            if (timer > 3.0f)
            {
                Debug.Log("ad");
                Destroy(gameObject);
            }
        }
        
    }

    void EnenmyMove()
    {
        float zMove = (moveSpeed * Time.deltaTime);
        transform.Translate(0, 0, zMove);
    }

   
}
