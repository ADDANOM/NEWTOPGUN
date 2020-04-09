using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Attack : MonoBehaviour
{
    Transform player_tr_1;
    int targetSelect;
    float selectTime;
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
    Boss_Health boss_Health;

    List<GameObject> boss_targets = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        boss_targets.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        if (boss_targets.Count == 1)
            boss_targets.Add(GameObject.FindGameObjectWithTag("Player"));
        
        anim = GetComponent<Animator>();
        boss_Health = GetComponent<Boss_Health>();

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


        if (Time.time > selectTime + 5.0f)
        {
            selectTime = Time.time;
            targetSelect = Random.Range(0, 2);

            if (targetSelect == 0)
            {
                Debug.Log("1 select");
                if (!boss_targets[0].GetComponent<PlayerHealth>().PlayerDeath)
                    player_tr_1 = boss_targets[0].transform;
                else
                    player_tr_1 = boss_targets[1].transform;
            }
            else
            {
                Debug.Log("2 select");
                if (!boss_targets[1].GetComponent<PlayerHealth>().PlayerDeath)
                    player_tr_1 = boss_targets[1].transform;
                else
                    player_tr_1 = boss_targets[0].transform;
            }
        }

        if (boss_Health.BossDeath)
            return;
        else if (!boss_targets[0].GetComponent<PlayerHealth>().PlayerDeath || !boss_targets[1].GetComponent<PlayerHealth>().PlayerDeath)
            Boss_attackPattern();
        else
            GameManager.player_bomb();

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
            if (Time.time > lastShootTime_1 + 0.2f)
            {
                lastShootTime_1 = Time.time;
                StartCoroutine(attack_right());
            }

        }
        if (bossAttackPatern == 6) // 좌현 통상 끝 
        {
            anim.SetBool("boss_pattern_right", false);
        }

        if (bossAttackPatern == 7)
        {
            if (boss_attack_center_left.localPosition.x >= -250.0f)
                boss_attack_center_left.Translate(new Vector3(-2.0f, 0.0f, -1.0f));
            else
            {
                boss_attack_center_left.localPosition = new Vector3(-57.0f, 0.0f, 250.0f);
            }

            if (boss_attack_center_right.localPosition.x <= 250.0f)
                boss_attack_center_right.Translate(new Vector3(2.0f, 0.0f, -1.0f));
            else
            {
                boss_attack_center_right.localPosition = new Vector3(57.0f, 0.0f, 250.0f);
            }

            if (Time.time > lastShootTime_2 + 0.3f)
            {
                lastShootTime_2 = Time.time;
                StartCoroutine(lastattack());
            }
        }
    }

    IEnumerator lastattack()
    {
        GameObject _bullet_big = Instantiate(bullet_rice, boss_attack_center_down.position, Quaternion.identity) as GameObject;
        _bullet_big.GetComponent<Transform>().localScale = new Vector3(40f, 60f, 30f);
        _bullet_big.GetComponent<Renderer>().material.color = Color.white;
        _bullet_big.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-(boss_attack_center_down.position.x - player_tr_1.position.x), -(boss_attack_center_down.position.y - player_tr_1.position.y), -(boss_attack_center_down.position.z - player_tr_1.position.z)).normalized
        * 10000.0f);

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
            _bullet_1.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(boss_attack_center_up.position.x - player_tr_1.position.x, player_tr_1.position.y - boss_attack_center_up.position.y, boss_attack_center_up.position.z - player_tr_1.position.z)
    * 50.0f);


            GameObject _bullet_2 = Instantiate(bullet_sphere, boss_attack_center_up.position, Quaternion.Euler(j * 30, 0, j * 30)) as GameObject;
            _bullet_2.GetComponent<Transform>().localScale = new Vector3(30f, 30f, 30f);
            _bullet_2.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(boss_attack_center_up.position.x - player_tr_1.position.x, player_tr_1.position.y - boss_attack_center_up.position.y, boss_attack_center_up.position.z - player_tr_1.position.z)
    * 50.0f);

            GameObject _bullet_3 = Instantiate(bullet_sphere, boss_attack_center_up.position, Quaternion.Euler(j * 15, j * 15 + 180, 0)) as GameObject;
            _bullet_3.GetComponent<Transform>().localScale = new Vector3(30f, 30f, 30f);
            _bullet_3.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(boss_attack_center_up.position.x - player_tr_1.position.x, player_tr_1.position.y - boss_attack_center_up.position.y, boss_attack_center_up.position.z - player_tr_1.position.z)
    * 50.0f);


        }
        yield return new WaitForSeconds(0.1f);
    }
    IEnumerator attack_left()
    {
        int rd1 = Random.Range(0, 50);
        int rd2 = Random.Range(0, 50);
        int rd3 = Random.Range(0, 50);

        GameObject _bullet_1 = Instantiate(bullet_sphere, boss_attack_left_center_1.position, Quaternion.identity) as GameObject;
        _bullet_1.GetComponent<Transform>().localScale = new Vector3(50f, 50f, 50f);

        _bullet_1.GetComponent<Rigidbody>().AddForce(new Vector3(boss_attack_left_center_1.position.x - player_tr_1.position.x + rd1, boss_attack_left_center_1.position.y - player_tr_1.position.y + rd1, boss_attack_left_center_1.position.z - player_tr_1.position.z + rd1).normalized * -8000.0f);

        GameObject _bullet_2 = Instantiate(bullet_sphere, boss_attack_left_center_2.position, Quaternion.identity) as GameObject;
        _bullet_2.GetComponent<Transform>().localScale = new Vector3(50f, 50f, 50f);

        _bullet_2.GetComponent<Rigidbody>().AddForce(new Vector3(boss_attack_left_center_2.position.x - player_tr_1.position.x + rd2, boss_attack_left_center_2.position.y - player_tr_1.position.y + rd2, boss_attack_left_center_2.position.z - player_tr_1.position.z + rd2).normalized * -8000.0f);

        GameObject _bullet_3 = Instantiate(bullet_sphere, boss_attack_left_center_3.position, Quaternion.identity) as GameObject;
        _bullet_3.GetComponent<Transform>().localScale = new Vector3(50f, 50f, 50f);

        _bullet_3.GetComponent<Rigidbody>().AddForce(new Vector3(boss_attack_left_center_3.position.x - player_tr_1.position.x + rd3, boss_attack_left_center_3.position.y - player_tr_1.position.y + rd3, boss_attack_left_center_3.position.z - player_tr_1.position.z + rd3).normalized * -8000.0f);


        GameObject _bullet_4 = Instantiate(bullet_sphere, boss_attack_left_front.position, Quaternion.identity) as GameObject;
        _bullet_4.GetComponent<Transform>().localScale = new Vector3(10f, 10f, 10f);
        _bullet_4.GetComponent<Rigidbody>().AddForce(new Vector3(boss_attack_left_front.position.x - player_tr_1.position.x, boss_attack_left_front.position.y - player_tr_1.position.y, boss_attack_left_front.position.z - player_tr_1.position.z).normalized * -12000.0f);

        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator attack_right()
    {
        int rd1 = Random.Range(0, 50);
        int rd2 = Random.Range(0, 50);
        int rd3 = Random.Range(0, 50);

        GameObject _bullet_1 = Instantiate(bullet_sphere, boss_attack_right_center_1.position, Quaternion.identity) as GameObject;
        _bullet_1.GetComponent<Transform>().localScale = new Vector3(10f, 10f, 10f);

        _bullet_1.GetComponent<Rigidbody>().AddForce(new Vector3(boss_attack_right_center_1.position.x - player_tr_1.position.x + rd1, boss_attack_right_center_1.position.y - player_tr_1.position.y + rd1, boss_attack_right_center_1.position.z - player_tr_1.position.z + rd1).normalized * -8000.0f);

        GameObject _bullet_2 = Instantiate(bullet_sphere, boss_attack_right_center_2.position, Quaternion.identity) as GameObject;
        _bullet_2.GetComponent<Transform>().localScale = new Vector3(10f, 10f, 10f);

        _bullet_2.GetComponent<Rigidbody>().AddForce(new Vector3(boss_attack_right_center_2.position.x - player_tr_1.position.x + rd2, boss_attack_right_center_2.position.y - player_tr_1.position.y + rd2, boss_attack_right_center_2.position.z - player_tr_1.position.z + rd2).normalized * -8000.0f);

        GameObject _bullet_3 = Instantiate(bullet_sphere, boss_attack_right_center_3.position, Quaternion.identity) as GameObject;
        _bullet_3.GetComponent<Transform>().localScale = new Vector3(10f, 10f, 10f);

        _bullet_3.GetComponent<Rigidbody>().AddForce(new Vector3(boss_attack_right_center_3.position.x - player_tr_1.position.x + rd3, boss_attack_right_center_3.position.y - player_tr_1.position.y + rd3, boss_attack_right_center_3.position.z - player_tr_1.position.z + rd3).normalized * -8000.0f);


        GameObject _bullet_4 = Instantiate(bullet_sphere, boss_attack_right_front.position, Quaternion.identity) as GameObject;
        _bullet_4.GetComponent<Transform>().localScale = new Vector3(50f, 50f, 50f);
        _bullet_4.GetComponent<Renderer>().material.color = Color.black;
        _bullet_4.GetComponent<Rigidbody>().AddForce(new Vector3(boss_attack_right_front.position.x - player_tr_1.position.x, boss_attack_right_front.position.y - player_tr_1.position.y, boss_attack_right_front.position.z - player_tr_1.position.z).normalized * -12000.0f);

        yield return new WaitForSeconds(0.1f);

    }



}
