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
            BossHealth.curBossHealth -= 1.0f;



            transform.SetParent(other.transform, true);
            particle.Play();
            transform.SetParent(null);
            if (!particle.isPlaying)
                gameObject.SetActive(false);
        }

    }
}
