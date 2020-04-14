using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    GameObject Fa;

    public float moveSpeed = 10.0f;  // EnenmyMove 속도값.

    public float EnemycurHealth = 1.0f;
    public bool isAlive = true;

    private AudioSource E_audio;


    void Start()
    {
        Fa = transform.gameObject;

        E_audio = GetComponent<AudioSource>();

    }
    void OnEnable()
    {
        GameManager.onBulletClear += BulletClear;
    }
    void OnDisable()
    {
        GameManager.onBulletClear -= BulletClear;
    }

    // Update is called once per frame
    void Update()
    {
        EnenmyMove();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && EnemycurHealth >= 1.0f)  // 직접 부딪힐 때
        {
            EnemycurHealth -= 10.0f;
            //ExPlosion.Play();  // 체력 0이 되면 실행하면된다. / 지금은 바로실행됨;  

            Debug.Log("E_Destroy");
            E_audio.Play();
            Destroy(Fa,0.5f);
        }

        if (other.gameObject.CompareTag("PLAYERBULLET"))
        {
            EnemycurHealth -= 1.0f;

            if (EnemycurHealth <= 0.0f)
            {
                E_audio.Play();
                Destroy(Fa,0.5f);
            }

        }
    }

    void EnenmyMove()
    {
        float zMove = (moveSpeed * Time.deltaTime);
        transform.Translate(0, 0, zMove);
    }
    void BulletClear()
    {
        Destroy(this.gameObject);
    }
}
