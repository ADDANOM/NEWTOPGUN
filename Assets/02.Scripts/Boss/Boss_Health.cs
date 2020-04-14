﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health : MonoBehaviour
{
    public float curBossHealth;
    public bool BossDeath = false;
    bool bossfall = false;
    ParticleSystem bossFire;
    Transform tr;

    private AudioSource B_audio;

    public GameObject clearCanv;
    private void Start()
    {
        tr = gameObject.transform.parent.GetComponent<Transform>();
        bossFire = GameObject.Find("BOSS_Fired").GetComponent<ParticleSystem>();
        curBossHealth = 20000.0f;

        B_audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (curBossHealth <= 0.0f)
            BossDeath = true;

        if (!bossFire.isPlaying && BossDeath)
        {
            bossFire.Play();
            bossfall = true;
        }
        if (bossfall)
        {
            tr.Translate(new Vector3(0, -2.0f, 2.0f) * 40 * Time.deltaTime);

            B_audio.Play();

            Destroy(tr.gameObject, 10.0f);

            StartCoroutine("ClearCanvas");
        }
    }
    
    IEnumerator ClearCanvas()
    {
        yield return new WaitForSeconds(3.0f);

        clearCanv.SetActive(true);
    }
}
