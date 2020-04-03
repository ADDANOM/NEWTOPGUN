using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Attack : MonoBehaviour
{
    float lastShootTime_1, lastShootTime_2;
    public GameObject bullet_rice;
    public GameObject bullet_sphere;
    GameObject Player_1;
    GameObject Player_2;

    Transform boss_attack_center_up;
    Transform boss_attack_center_right;
    Transform boss_attack_center_left;
    Transform boss_attack_center_down;
    Transform boss_attack_right_center_1;
    Transform boss_attack_right_center_2;
    Transform boss_attack_right_center_3;
    Transform boss_attack_right_front;
    Transform boss_attack_left_center_1;
    Transform boss_attack_left_center_2;
    Transform boss_attack_left_center_3;
    Transform boss_attack_left_front;
    Transform boss_attack_middle_center;


    // Start is called before the first frame update
    void Start()
    {
        Player_1 = GameObject.Find("Player");
        Player_2 = GameObject.Find("Player(1)");

        boss_attack_center_up = transform.Find("BOSS_Attackplaces").transform.Find("boss_attack_center_up").GetComponent<Transform>();
        boss_attack_center_right = transform.Find("BOSS_Attackplaces").transform.Find("boss_attack_center_right").GetComponent<Transform>();
        boss_attack_center_left = transform.Find("BOSS_Attackplaces").transform.Find("boss_attack_center_left").GetComponent<Transform>();
        boss_attack_center_down = transform.Find("BOSS_Attackplaces").transform.Find("boss_attack_center_down").GetComponent<Transform>();
        boss_attack_right_center_1 = transform.Find("BOSS_Attackplaces").transform.Find("boss_attack_right_center_1").GetComponent<Transform>();
        boss_attack_right_center_2 = transform.Find("BOSS_Attackplaces").transform.Find("boss_attack_right_center_2").GetComponent<Transform>();
        boss_attack_right_center_3 = transform.Find("BOSS_Attackplaces").transform.Find("boss_attack_right_center_3").GetComponent<Transform>();
        boss_attack_right_front = transform.Find("BOSS_Attackplaces").transform.Find("boss_attack_right_front").GetComponent<Transform>();
        boss_attack_left_center_1 = transform.Find("BOSS_Attackplaces").transform.Find("boss_attack_left_center_1").GetComponent<Transform>();
        boss_attack_left_center_2 = transform.Find("BOSS_Attackplaces").transform.Find("boss_attack_left_center_2").GetComponent<Transform>();
        boss_attack_left_center_3 = transform.Find("BOSS_Attackplaces").transform.Find("boss_attack_left_center_3").GetComponent<Transform>();
        boss_attack_left_front = transform.Find("BOSS_Attackplaces").transform.Find("boss_attack_left_front").GetComponent<Transform>();
        boss_attack_middle_center = transform.Find("BOSS_Attackplaces").transform.Find("boss_attack_middle_center").GetComponent<Transform>();




    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Boss_attackPattern();

    }


    void Boss_attackPattern()
    {
        
        if (boss_attack_center_up.localPosition.z <= 800.0f)
            boss_attack_center_up.Translate(new Vector3(0.0f, 0.0f, 1.0f));
        else
        {
            boss_attack_center_up.position = new Vector3(0.0f, 0.0f, 250.0f);
        }


        if (Time.time > lastShootTime_1 + 0.5f)
        {
            lastShootTime_1 = Time.time;
            StartCoroutine(attack());
        }

        if (Time.time > lastShootTime_2 + 1.0f)
        {
            lastShootTime_2 = Time.time;
            StartCoroutine(attack2());
        }

    }

    IEnumerator attack()
    {

        for (int i = 0; i < 1; i++)
        {
            //Instantiate(bullet_rice, boss_attack_center_up.position, boss_attack_center_up.rotation);

            for (int j = 0; j < 6; j++)
            {
                Instantiate(bullet_rice, boss_attack_center_up.position, Quaternion.Euler(0, j * 60, j * 60));
                Instantiate(bullet_rice, boss_attack_center_up.position, Quaternion.Euler(j * 60, 0, j * 60));
                Instantiate(bullet_rice, boss_attack_center_up.position, Quaternion.Euler(j * 60, j * 60, 0));
            }
            yield return new WaitForSeconds(0.1f);

        }
    }

    IEnumerator attack2()
    {
        Instantiate(bullet_sphere, boss_attack_center_left.position, boss_attack_center_left.rotation);
        Instantiate(bullet_sphere, boss_attack_center_right.position, boss_attack_center_right.rotation);
        yield return new WaitForSeconds(0.1f);
    }

}
