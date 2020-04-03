using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Attack : MonoBehaviour
{
    Transform player_tr_1; Transform player_tr_2;
    float lastShootTime_1, lastShootTime_2;
    public GameObject bullet_rice;
    public GameObject bullet_sphere;
    public Transform bossPosition;
    public int bossAttackPatern;
    Animator anim;

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
        anim = GetComponent<Animator>();
        player_tr_1 = GameObject.Find("Player").transform;
        // Player_2 = GameObject.Find("Player(1)");

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

        if (bossAttackPatern == 1) // 통상 정면 1
        {

            if (boss_attack_center_up.localPosition.z <= 800.0f)
                boss_attack_center_up.Translate(new Vector3(0.0f, 0.0f, 1.0f));
            else
            {
                boss_attack_center_up.localPosition = new Vector3(0.0f, 0.0f, 250.0f);
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

        if (bossAttackPatern == 2) // 통상 정면 2
        {
            boss_attack_center_up.localPosition = new Vector3(0.0f, 0.0f, 250.0f);
            if (Time.time > lastShootTime_1 + 0.5f)
            {
                lastShootTime_1 = Time.time;
                StartCoroutine(attack3());
            }

        }

        if (bossAttackPatern == 3) // 좌현 통상 공격
        {
            anim.SetBool("boss_pattern_left", true);
            if (Time.time > lastShootTime_1 + 0.2f)
            {
                lastShootTime_1 = Time.time;
                StartCoroutine(attack_left());
            }
        }
        if (bossAttackPatern == 4) // 좌현 통상 끝 
        {
            anim.SetBool("boss_pattern_left", false);

        }
        if (bossAttackPatern == 5) // 좌현 통상 공격
        {
            anim.SetBool("boss_pattern_right", true);



        }
        if (bossAttackPatern == 6) // 좌현 통상 끝 
        {

            anim.SetBool("boss_pattern_right", false);
        }



    }

    IEnumerator attack()
    {
        for (int j = 0; j < 6; j++) // 정면
        {
            GameObject _bullet_1 = Instantiate(bullet_rice, boss_attack_center_up.position, Quaternion.Euler(0, j * 60, j * 60)) as GameObject;
            _bullet_1.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(transform.position.x - player_tr_1.position.x, player_tr_1.position.y - transform.position.y, transform.position.z - player_tr_1.position.z)
            * 30.0f);

            GameObject _bullet_2 = Instantiate(bullet_rice, boss_attack_center_up.position, Quaternion.Euler(j * 60, 0, j * 60)) as GameObject;
            _bullet_2.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(transform.position.x - player_tr_1.position.x, player_tr_1.position.y - transform.position.y, transform.position.z - player_tr_1.position.z)
            * 30.0f);

            GameObject _bullet_3 = Instantiate(bullet_rice, boss_attack_center_up.position, Quaternion.Euler(j * 60, j * 60, 0)) as GameObject;
            _bullet_3.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(transform.position.x - player_tr_1.position.x, player_tr_1.position.y - transform.position.y, transform.position.z - player_tr_1.position.z)
            * 30.0f);
        }
        yield return new WaitForSeconds(0.1f);

    }

    IEnumerator attack2()
    {

        GameObject _bullet_1 = Instantiate(bullet_sphere, boss_attack_center_left.position + new Vector3(0.0f, 50.0f, 0.0f), boss_attack_center_left.rotation) as GameObject;
        _bullet_1.GetComponent<Transform>().localScale = new Vector3(30f, 30f, 30f);
        _bullet_1.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(transform.position.x - player_tr_1.position.x, player_tr_1.position.y - transform.position.y, transform.position.z - player_tr_1.position.z)
        * 30.0f);

        GameObject _bullet_2 = Instantiate(bullet_sphere, boss_attack_center_left.position + new Vector3(0.0f, -50.0f, 0.0f), boss_attack_center_left.rotation) as GameObject;
        _bullet_2.GetComponent<Transform>().localScale = new Vector3(30f, 30f, 30f);
        _bullet_2.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(transform.position.x - player_tr_1.position.x, player_tr_1.position.y - transform.position.y, transform.position.z - player_tr_1.position.z)
        * 30.0f);

        GameObject _bullet_3 = Instantiate(bullet_sphere, boss_attack_center_left.position + new Vector3(0.0f, 0.0f, 0.0f), boss_attack_center_left.rotation) as GameObject;
        _bullet_3.GetComponent<Transform>().localScale = new Vector3(30f, 30f, 30f);
        _bullet_3.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(transform.position.x - player_tr_1.position.x, player_tr_1.position.y - transform.position.y, transform.position.z - player_tr_1.position.z)
        * 30.0f);


        GameObject _bullet_4 = Instantiate(bullet_sphere, boss_attack_center_right.position + new Vector3(0.0f, -50.0f, 0.0f), boss_attack_center_right.rotation) as GameObject;
        _bullet_4.GetComponent<Transform>().localScale = new Vector3(30f, 30f, 30f);
        _bullet_4.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(transform.position.x - player_tr_1.position.x, player_tr_1.position.y - transform.position.y, transform.position.z - player_tr_1.position.z)
        * 30.0f);
        GameObject _bullet_5 = Instantiate(bullet_sphere, boss_attack_center_right.position + new Vector3(0.0f, 50.0f, 0.0f), boss_attack_center_right.rotation) as GameObject;
        _bullet_5.GetComponent<Transform>().localScale = new Vector3(30f, 30f, 30f);
        _bullet_5.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(transform.position.x - player_tr_1.position.x, player_tr_1.position.y - transform.position.y, transform.position.z - player_tr_1.position.z)
        * 30.0f);
        GameObject _bullet_6 = Instantiate(bullet_sphere, boss_attack_center_right.position + new Vector3(0.0f, 0.0f, 0.0f), boss_attack_center_right.rotation) as GameObject;
        _bullet_6.GetComponent<Transform>().localScale = new Vector3(30f, 30f, 30f);
        _bullet_6.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(transform.position.x - player_tr_1.position.x, player_tr_1.position.y - transform.position.y, transform.position.z - player_tr_1.position.z)
        * 30.0f);

        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator attack3()
    {

        for (int j = 0; j < 12; j++)
        {
            GameObject _bullet_1 = Instantiate(bullet_sphere, boss_attack_center_up.position, Quaternion.Euler(0, j * 30, j * 30)) as GameObject;
            _bullet_1.GetComponent<Transform>().localScale = new Vector3(30f, 30f, 30f);
            _bullet_1.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(transform.position.x - player_tr_1.position.x, player_tr_1.position.y - transform.position.y, transform.position.z - player_tr_1.position.z)
    * 50.0f);


            GameObject _bullet_2 = Instantiate(bullet_sphere, boss_attack_center_up.position, Quaternion.Euler(j * 30, 0, j * 30)) as GameObject;
            _bullet_2.GetComponent<Transform>().localScale = new Vector3(30f, 30f, 30f);
            _bullet_2.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(transform.position.x - player_tr_1.position.x, player_tr_1.position.y - transform.position.y, transform.position.z - player_tr_1.position.z)
    * 50.0f);

            GameObject _bullet_3 = Instantiate(bullet_sphere, boss_attack_center_up.position, Quaternion.Euler(j * 15, j * 15 + 180, 0)) as GameObject;
            _bullet_3.GetComponent<Transform>().localScale = new Vector3(30f, 30f, 30f);
            _bullet_3.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(transform.position.x - player_tr_1.position.x, player_tr_1.position.y - transform.position.y, transform.position.z - player_tr_1.position.z)
    * 50.0f);


        }
        yield return new WaitForSeconds(0.1f);
    }
    IEnumerator attack_left()
    {
        int rd1 = Random.Range(0, 50);
        int rd2 = Random.Range(0, 50);
        int rd3 = Random.Range(0, 50);

        GameObject _bullet_1 = Instantiate(bullet_sphere, boss_attack_left_center_1.position, boss_attack_left_center_1.rotation) as GameObject;
        _bullet_1.GetComponent<Transform>().localScale = new Vector3(50f, 50f, 50f);

        _bullet_1.GetComponent<Rigidbody>().AddForce(new Vector3(transform.position.x - player_tr_1.position.x + rd1, rd1, transform.position.z - player_tr_1.position.z) * -40.0f);

        GameObject _bullet_2 = Instantiate(bullet_sphere, boss_attack_left_center_2.position, boss_attack_left_center_2.rotation) as GameObject;
        _bullet_2.GetComponent<Transform>().localScale = new Vector3(50f, 50f, 50f);

        _bullet_2.GetComponent<Rigidbody>().AddForce(new Vector3(transform.position.x - player_tr_1.position.x + rd2, rd2, transform.position.z - player_tr_1.position.z) * -40.0f);

        GameObject _bullet_3 = Instantiate(bullet_sphere, boss_attack_left_center_3.position, boss_attack_left_center_3.rotation) as GameObject;
        _bullet_3.GetComponent<Transform>().localScale = new Vector3(50f, 50f, 50f);

        _bullet_3.GetComponent<Rigidbody>().AddForce(new Vector3(transform.position.x - player_tr_1.position.x + rd3, rd3, transform.position.z - player_tr_1.position.z) * -40.0f);


        GameObject _bullet_4 = Instantiate(bullet_sphere, boss_attack_left_front.position, boss_attack_left_front.rotation) as GameObject;
        _bullet_4.GetComponent<Transform>().localScale = new Vector3(20f, 20f, 20f);
        _bullet_4.GetComponent<Rigidbody>().AddForce(new Vector3(transform.position.x - player_tr_1.position.x, transform.position.y - player_tr_1.position.y, transform.position.z - player_tr_1.position.z)
        * -100.0f);


        yield return new WaitForSeconds(0.1f);

    }

}
