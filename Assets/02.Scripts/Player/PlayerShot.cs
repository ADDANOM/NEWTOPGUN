using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public GameObject mainshotPos;
    public GameObject subshotPos_a;
    public GameObject subshotPos_b;
    public GameObject subshotPos_a_2;
    public GameObject subshotPos_b_2;

    GameObject bomb_1, bomb_2, bomb_3, bomb_4;

    GameObject shotPos;
    public int shotLevel;
    public int bombStock;
    int preBombStock;
    private ParticleSystem Bomb;
    private float nextBomb = 0.0f;
    private float bombRate = 3.0f;

    private Boss_Health boss_health;


    private void Awake()
    {
        shotLevel = 1;
        bombStock = 4;
        shotPos = transform.Find("ShotPos").gameObject;

        mainshotPos.GetComponent<PlayerFire>().enabled = true;
        subshotPos_a.GetComponent<PlayerSubFire>().enabled = false;
        subshotPos_b.GetComponent<PlayerSubFire>().enabled = false;
        subshotPos_a_2.GetComponent<PlayerSubFire>().enabled = false;
        subshotPos_b_2.GetComponent<PlayerSubFire>().enabled = false;

        Bomb = transform.Find("Bomb_Effect").GetComponent<ParticleSystem>();
        boss_health = GameObject.Find("Boss_position").transform.Find("BOSS").GetComponent<Boss_Health>();

        bomb_1 = transform.Find("FighterInterceptor").transform.Find("BombPos").transform.Find("BOMB_missile_1").gameObject;
        bomb_2 = transform.Find("FighterInterceptor").transform.Find("BombPos").transform.Find("BOMB_missile_2").gameObject;
        bomb_3 = transform.Find("FighterInterceptor").transform.Find("BombPos").transform.Find("BOMB_missile_3").gameObject;
        bomb_4 = transform.Find("FighterInterceptor").transform.Find("BombPos").transform.Find("BOMB_missile_4").gameObject;
    }

    private void Update()
    {

        if (preBombStock != bombStock)
        {
            if (bombStock > 3)
            {
                BOMB_4();
            }
            else if (bombStock > 2)
            {
                BOMB_3();
            }
            else if (bombStock > 1)
            {
                BOMB_2();
            }
            else if (bombStock > 0)
            {
                BOMB_1();
            }
            else
            {
                BOMB_0();
            }
        }
        preBombStock = bombStock;
    }

    void BOMB_4()
    {
        bomb_1.SetActive(true);
        bomb_2.SetActive(true);
        bomb_3.SetActive(true);
        bomb_4.SetActive(true);
    }
    void BOMB_3()
    {
        bomb_1.SetActive(true);
        bomb_2.SetActive(true);
        bomb_3.SetActive(true);
        bomb_4.SetActive(false);
    }
    void BOMB_2()
    {
        bomb_1.SetActive(true);
        bomb_2.SetActive(true);
        bomb_3.SetActive(false);
        bomb_4.SetActive(false);
    }
    void BOMB_1()
    {
        bomb_1.SetActive(true);
        bomb_2.SetActive(false);
        bomb_3.SetActive(false);
        bomb_4.SetActive(false);
    }
    void BOMB_0()
    {
        bomb_1.SetActive(false);
        bomb_2.SetActive(false);
        bomb_3.SetActive(false);
        bomb_4.SetActive(false);
    }


    public void doBomb()
    {

        if (!Bomb.isPlaying && Time.time >= nextBomb && bombStock > 0)
        {
            bombStock -= 1;
            Bomb.Play();
            GameManager.player_bomb();
            nextBomb = Time.time + bombRate;
            boss_health.curBossHealth -= 500.0f;
        }

    }

    public void shotLevel_1()
    {
        mainshotPos.GetComponent<PlayerFire>().enabled = true;
        subshotPos_a.GetComponent<PlayerSubFire>().enabled = false;
        subshotPos_b.GetComponent<PlayerSubFire>().enabled = false;
        subshotPos_a_2.GetComponent<PlayerSubFire>().enabled = false;
        subshotPos_b_2.GetComponent<PlayerSubFire>().enabled = false;
    }
    public void shotLevel_2()
    {
        mainshotPos.GetComponent<PlayerFire>().enabled = true;
        subshotPos_a.GetComponent<PlayerSubFire>().enabled = true;
        subshotPos_b.GetComponent<PlayerSubFire>().enabled = true;
        subshotPos_a_2.GetComponent<PlayerSubFire>().enabled = false;
        subshotPos_b_2.GetComponent<PlayerSubFire>().enabled = false;
    }
    public void shotLevel_3()
    {
        mainshotPos.GetComponent<PlayerFire>().enabled = true;
        subshotPos_a.GetComponent<PlayerSubFire>().enabled = true;
        subshotPos_b.GetComponent<PlayerSubFire>().enabled = true;
        subshotPos_a_2.GetComponent<PlayerSubFire>().enabled = true;
        subshotPos_b_2.GetComponent<PlayerSubFire>().enabled = true;
    }


    public void shotEnable()
    {
        shotPos.SetActive(true);
    }

    public void shotDisable()
    {
        shotPos.SetActive(false);
    }

}
