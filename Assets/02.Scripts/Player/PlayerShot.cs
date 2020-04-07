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

    GameObject shotPos;
    public int shotLevel;
    public int bombStock;
    private ParticleSystem Bomb;
    private float nextBomb = 0.0f;
    private float bombRate = 3.0f;
    private Boss_Health boss_health;


    private void Awake()
    {
        shotLevel = 1;
        bombStock = 3;
        shotPos = transform.Find("ShotPos").gameObject;

        mainshotPos.GetComponent<PlayerFire>().enabled = true;
        subshotPos_a.GetComponent<PlayerSubFire>().enabled = false;
        subshotPos_b.GetComponent<PlayerSubFire>().enabled = false;
        subshotPos_a_2.GetComponent<PlayerSubFire>().enabled = false;
        subshotPos_b_2.GetComponent<PlayerSubFire>().enabled = false;

        Bomb = transform.Find("Bomb_Effect").GetComponent<ParticleSystem>();
        boss_health = GameObject.Find("Boss_position").transform.Find("BOSS").GetComponent<Boss_Health>();

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
