using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject BOSS;
    GameObject spawnMgr;
    Transform boss_tr;

    Boss_Attack bossAttack;
    Boss_Health boss_Health;

    float timer;


    public static GameManager instans = null;  // 싱글턴 타입으로 만든다. 




    private void Awake()
    {

        instans = this;
    }

    void Start()
    {
        spawnMgr = GameObject.Find("SpawnMgr").gameObject;
        BOSS = GameObject.Find("Boss_position").transform.Find("BOSS").gameObject;
        boss_tr = GameObject.Find("Boss_position").GetComponent<Transform>();

        spawnMgr.SetActive(false);
        BOSS.SetActive(false);

        bossAttack = BOSS.GetComponent<Boss_Attack>();
        boss_Health = BOSS.GetComponent<Boss_Health>();
        timer = 0;
    }
    void FixedUpdate()
    {
        timer = Time.time;

        if (timer == 1.0f)
        {
            spawnMgr.SetActive(true);
        }
        else if (timer >= 60.0f && timer <=65.0f)
        {
            spawnMgr.SetActive(false);
            BOSS.SetActive(true);
            boss_tr.Translate(new Vector3(0.0f,5.0f,0.0f)*25*Time.deltaTime);
        }
        else if (timer > 65.0f)
            bossPattern();

    }

    void bossPattern()
    {
        if (boss_Health.curBossHealth > 17000.0f)
        {
            bossAttack.bossAttackPatern = 1;
        }
        else if (boss_Health.curBossHealth > 14000.0f && boss_Health.curBossHealth <= 17000.0f)
        {
            bossAttack.bossAttackPatern = 2;
        }
        else if (boss_Health.curBossHealth > 10000.0f && boss_Health.curBossHealth <= 14000.0f)
        {
            bossAttack.bossAttackPatern = 3;
        }
        else if (boss_Health.curBossHealth > 6000.0f && boss_Health.curBossHealth <= 10000.0f)
        {
            if (bossAttack.bossAttackPatern == 3)
                bossAttack.bossAttackPatern = 4;
            else
                bossAttack.bossAttackPatern = 5;
        }
        else if (boss_Health.curBossHealth > 0.0f && boss_Health.curBossHealth <= 6000.0f)
        {
            if (bossAttack.bossAttackPatern == 5)
                bossAttack.bossAttackPatern = 6;
            else
                bossAttack.bossAttackPatern = 7;
        }
        else
            bossAttack.bossAttackPatern = 0;

    }

    public delegate void enemyBulletClearHandler();
    public static event enemyBulletClearHandler onBulletClear;

    public static void player_bomb()
    {
        onBulletClear();
    }


}
