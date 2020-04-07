using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject BOSS;
    Boss_Attack bossAttack;
    Boss_Health boss_Health;


    public static GameManager instans = null;  // 싱글턴 타입으로 만든다. 




    private void Awake()
    {
        instans = this;

    }

    void Start()
    {
        BOSS = GameObject.Find("Boss_position").transform.Find("BOSS").gameObject;
        bossAttack = BOSS.GetComponent<Boss_Attack>();
        boss_Health = BOSS.GetComponent<Boss_Health>();

        

    }

    void Update()
    {
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


    
}
