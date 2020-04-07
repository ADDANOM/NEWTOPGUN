using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetitem : MonoBehaviour
{
    PlayerShot playerShot;
    PlayerHealth playerHealth;


    void Start()
    {
        playerShot = gameObject.transform.parent.GetComponent<PlayerShot>();
        playerHealth = gameObject.transform.parent.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Misile"))
        {
            if (playerShot.shotLevel == 1 && playerHealth.curPlayerHealth > 0)
            {
                playerShot.shotLevel_2();
                playerShot.shotLevel = 2;
            }
            else if (playerShot.shotLevel == 2 && playerHealth.curPlayerHealth > 0)
            {
                playerShot.shotLevel_3();
                playerShot.shotLevel = 3;
            }

            if (playerHealth.curPlayerHealth > 0)
            {
                Destroy(other.gameObject);
            }
            
        }
        else if (other.gameObject.name.Contains("Heal"))
        {
            if (playerHealth.curPlayerHealth < 5 && playerHealth.curPlayerHealth > 0)
            {
                playerHealth.curPlayerHealth += 1;
            }

            if (playerHealth.curPlayerHealth > 0)
            {
                Destroy(other.gameObject);
            }
        }
        else if (other.gameObject.name.Contains("Boom"))
        {
            if (playerShot.bombStock <= 2 && playerHealth.curPlayerHealth > 0)
            {
                playerShot.bombStock += 1;
            }

            if (playerHealth.curPlayerHealth > 0)
            {
                Destroy(other.gameObject);
            }
        }



    }




}
