using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    GameObject Fa;

    public float moveSpeed = 10.0f;  // EnenmyMove 속도값.

    public float EnemycurHealth = 10.0f;
    public bool isAlive = true;



    private float timer;
    

    void Start()
    {
        Fa = transform.gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        EnenmyMove();

       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && EnemycurHealth >= 1.0f)  // 직접 부딪힐 때
        {
            EnemycurHealth -= 10.0f;
            //ExPlosion.Play();  // 체력 0이 되면 실행하면된다. / 지금은 바로실행됨;  

            Debug.Log("Destroy");
            Destroy(Fa);
        }
        else if (other.gameObject.CompareTag("PLAYERBULLET"))
        {
            EnemycurHealth -= 2.0f;
            
            if(EnemycurHealth == 0.0f)
            {
                Destroy(Fa);
            }

        }
    }

    void EnenmyMove()
    {
        float zMove = (moveSpeed * Time.deltaTime);
        transform.Translate(0, 0, zMove);
    }

}
