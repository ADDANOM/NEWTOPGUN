using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerHealth : MonoBehaviourPunCallbacks
{
    float prePlayerHealth;
    public float curPlayerHealth;
    public bool PlayerDeath = false;
    public bool gameOver = false;
    MeshRenderer needRescue;
    ParticleSystem smoke;
    ParticleSystem repairParticle;
    ParticleSystem fireEffect;
    float lastDamageTime;
    float lastRescueTime;
    float immotalTime;
    PlayerMove PlayerMove;
    Transform tr;
    GameObject shotPos;
    GameObject hp_1, hp_2, hp_3, hp_4, hp_5;
    GameObject hpBar;
    GameObject laser;

    private AudioSource myaudio;
    public AudioClip P_DamagedSounds;

    public Color flashCol = new Color(1f, 0f, 0f, 0.4f);
    GameObject damageImage;
    bool damaged = true;
    public GameObject gameoverPanel;

    private void Start()
    {
        curPlayerHealth = 25.0f;

        tr = GetComponent<Transform>();
        PlayerMove = GetComponent<PlayerMove>();
        needRescue = transform.Find("FighterInterceptor").transform.Find("Fuselage").GetComponent<MeshRenderer>();
        smoke = transform.Find("DestroySmoke").GetComponent<ParticleSystem>();
        repairParticle = transform.Find("RepairParticle").GetComponent<ParticleSystem>();
        fireEffect = transform.Find("FighterInterceptor").transform.Find("Fire_Effect").GetComponent<ParticleSystem>();
        shotPos = transform.Find("ShotPos").gameObject;

        gameoverPanel = GameObject.Find("CameraRig").transform.Find("Camera").transform.Find("Canvas").transform.Find("GameOver").gameObject;


        hp_1 = GameObject.Find("CameraRig").transform.Find("Camera").transform.Find("Canvas_UI").transform.Find("HP_Panel").transform.Find("HP_1").gameObject;
        hp_2 = GameObject.Find("CameraRig").transform.Find("Camera").transform.Find("Canvas_UI").transform.Find("HP_Panel").transform.Find("HP_2").gameObject;
        hp_3 = GameObject.Find("CameraRig").transform.Find("Camera").transform.Find("Canvas_UI").transform.Find("HP_Panel").transform.Find("HP_3").gameObject;
        hp_4 = GameObject.Find("CameraRig").transform.Find("Camera").transform.Find("Canvas_UI").transform.Find("HP_Panel").transform.Find("HP_4").gameObject;
        hp_5 = GameObject.Find("CameraRig").transform.Find("Camera").transform.Find("Canvas_UI").transform.Find("HP_Panel").transform.Find("HP_5").gameObject;

        damageImage = GameObject.Find("CameraRig").transform.Find("Camera").transform.Find("Canvas").transform.Find("Damaged").gameObject;
        hpBar = GameObject.Find("CameraRig").transform.Find("Camera").transform.Find("Canvas_UI").gameObject;
        laser = GameObject.Find("CameraRig").transform.Find("Camera").transform.Find("[CameraRig]").gameObject;

        myaudio = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("BULLET") && !PlayerDeath && (Time.time > lastDamageTime + 2.0f) && (Time.time > immotalTime + 2.0f))
        {
            if (curPlayerHealth > 1.0f)
            {
                lastDamageTime = Time.time;
                curPlayerHealth -= 1.0f;
            }
            else
            {
                Destroyed();
            }

        }

        if (other.gameObject.name is "RepairZone" && PlayerDeath)
        {
            bool otherDeath = other.gameObject.transform.parent.GetComponent<PlayerHealth>().PlayerDeath;
            if (gameOver)
            {
                Debug.Log("already gameOver");
            }
            else if (!otherDeath && !gameOver && (Time.time > lastRescueTime + 10.0f))
            {
                Repaired();
                lastRescueTime = Time.time;
                immotalTime = Time.time;
            }
            else if (!otherDeath && !gameOver && (Time.time < lastRescueTime + 10.0f))
                Debug.Log($"{5 + lastRescueTime - Time.time} seconds later");
        }

        if (other.gameObject.name is "Zone_South" && PlayerDeath)
        {
            gameOver = true;
        }
    }

    private void FixedUpdate()
    {
        Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);
        if (photonView.IsMine)
        {
            if (PlayerDeath && PhotonNetwork.CurrentRoom.PlayerCount == 1)
            {
                gameoverPanel.SetActive(true);
                GameOver();
                PlayerMove.enabled = false;
            }
            else
                gameoverPanel.SetActive(false);

            if (PhotonNetwork.CurrentRoom.PlayerCount == 2 && PlayerDeath && PlayerMove.death_other)
            {
                Debug.Log("ddddd");
                gameoverPanel.SetActive(true);
                GameOver();
                PlayerMove.enabled = false;

            }
            else
                gameoverPanel.SetActive(false);




            if (prePlayerHealth != curPlayerHealth)
            {
                if (curPlayerHealth > 20.0f)
                {
                    HP_5();
                }
                else if (curPlayerHealth > 15.0f)
                {
                    HP_4();
                    myaudio.clip = P_DamagedSounds;
                    myaudio.Play();

                    if (damaged)
                    {
                        StartCoroutine("Damaging");
                    }
                }
                else if (curPlayerHealth > 10.0f)
                {
                    HP_3();
                    myaudio.clip = P_DamagedSounds;
                    myaudio.Play();

                    if (damaged)
                    {
                        StartCoroutine("Damaging");
                    }
                }
                else if (curPlayerHealth > 5.0f)
                {
                    HP_2();

                    myaudio.clip = P_DamagedSounds;
                    myaudio.Play();

                    if (damaged)
                    {
                        StartCoroutine("Damaging");
                    }
                }
                else if (curPlayerHealth > 0.0f)
                {
                    HP_1();

                    myaudio.clip = P_DamagedSounds;
                    myaudio.Play();

                    if (damaged)
                    {
                        StartCoroutine("Damaging");
                    }
                }
                else if (curPlayerHealth == 0.0f)
                {
                    HP_0();

                    myaudio.clip = P_DamagedSounds;
                    myaudio.Play();

                    if (damaged)
                    {
                        StartCoroutine("Damaging");
                    }
                }

            }
        }
        else
        {
            curPlayerHealth = PlayerMove.health_other;
            PlayerDeath = PlayerMove.death_other;
        }




        if (PlayerDeath)
        {
            tr.Translate(new Vector3(0, -0.04f, -0.1f));
        }

        prePlayerHealth = curPlayerHealth;

    }

    void HP_5()
    {
        hp_1.SetActive(true);
        hp_2.SetActive(true);
        hp_3.SetActive(true);
        hp_4.SetActive(true);
        hp_5.SetActive(true);
    }

    void HP_4()
    {
        hp_1.SetActive(true);
        hp_2.SetActive(true);
        hp_3.SetActive(true);
        hp_4.SetActive(true);
        hp_5.SetActive(false);
    }

    void HP_3()
    {
        damaged = true;

        hp_1.SetActive(true);
        hp_2.SetActive(true);
        hp_3.SetActive(true);
        hp_4.SetActive(false);
        hp_5.SetActive(false);

    }

    void HP_2()
    {
        damaged = true;

        hp_1.SetActive(true);
        hp_2.SetActive(true);
        hp_3.SetActive(false);
        hp_4.SetActive(false);
        hp_5.SetActive(false);
    }
    void HP_1()
    {
        StartCoroutine(("Damaging"));

        hp_1.SetActive(true);
        hp_2.SetActive(false);
        hp_3.SetActive(false);
        hp_4.SetActive(false);
        hp_5.SetActive(false);
    }

    void HP_0()
    {
        StartCoroutine(("Damaging"));

        hp_1.SetActive(false);
        hp_2.SetActive(false);
        hp_3.SetActive(false);
        hp_4.SetActive(false);
        hp_5.SetActive(false);
    }


    void Destroyed()
    {
        curPlayerHealth = 0.0f;
        PlayerDeath = true;
        needRescue.material.color = new Color(1, 0, 0, 1);
        smoke.Play();
        fireEffect.Stop();
        shotPos.SetActive(false);
    }
    void Repaired()
    {
        curPlayerHealth = 5.0f;
        PlayerDeath = false;
        needRescue.material.color = new Color(0.5882f, 0.5882f, 0.5882f, 1);
        smoke.Stop();
        repairParticle.Play();
        shotPos.SetActive(true);
    }

    void GameOver()
    {
        hpBar.SetActive(false);
        laser.SetActive(true);
    }

    IEnumerator Damaging()
    {
        damageImage.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        damageImage.SetActive(false);
        Debug.Log("333");
        damaged = false;
    }

}
