using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireDamage : MonoBehaviour
{
    Boss_Health BossHealth;
    ParticleSystem particle;
    void Start()
    {
        BossHealth = GameObject.Find("Boss_position").transform.Find("BOSS").GetComponent<Boss_Health>();
        particle = this.transform.Find("missile_explosion_small").GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BOSS"))
        {
            if (BossHealth.curBossHealth > 1.0f)
                BossHealth.curBossHealth -= 1.0f;
            else
                BossHealth.BossDeath = true;


            transform.SetParent(other.transform, true);
            particle.Play();
            transform.SetParent(null);
            if (!particle.isPlaying)
                gameObject.SetActive(false);
        }

    }
}
