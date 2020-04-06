using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health : MonoBehaviour
{
    public float curBossHealth;
    public bool BossDeath = false;

    private void Start() {
        curBossHealth = 20000.0f;
    }

}
