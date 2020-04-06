using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float curPlayerHealth = 3.0f;
    public bool PlayerDeath = false;




    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        if (other.gameObject.CompareTag("BULLET"))
        {
            if (curPlayerHealth > 1.0f)
                curPlayerHealth -= 1.0f;
            else
                PlayerDeath = true;
        }

    }



}
