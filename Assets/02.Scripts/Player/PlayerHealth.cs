using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float curPlayerHealth = 3.0f;
    public bool PlayerDeath = false;
    public bool gameOver = false;
    public Slider slider;
    MeshRenderer needRescue;
    ParticleSystem smoke;
    ParticleSystem repairParticle;
    ParticleSystem fireEffect;
    float sliderHealth;
    float lastDamageTime;
    float lastRescueTime;
    float immotalTime;
    PlayerMove PlayerMove;
    Transform tr;

    GameObject shotPos;


    private void Start()
    {
        tr = GetComponent<Transform>();
        PlayerMove = GetComponent<PlayerMove>();
        sliderHealth = slider.value;
        needRescue = transform.Find("FighterInterceptor").transform.Find("Fuselage").GetComponent<MeshRenderer>();
        smoke = transform.Find("DestroySmoke").GetComponent<ParticleSystem>();
        repairParticle = transform.Find("RepairParticle").GetComponent<ParticleSystem>();
        fireEffect = transform.Find("FighterInterceptor").transform.Find("Fire_Effect").GetComponent<ParticleSystem>();
        shotPos = transform.Find("ShotPos").gameObject;
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
                Destroyed();
        }
        sliderHealth = curPlayerHealth;

        if (other.gameObject.name is "RepairZone" && PlayerDeath)
        {
            bool otherDeath = other.gameObject.transform.parent.GetComponent<PlayerHealth>().PlayerDeath;
            if (gameOver)
            {
                Debug.Log("already gameOver"); 
            }
            else if (!otherDeath && !gameOver && (Time.time > lastRescueTime + 5.0f))
            {
                Repaired();
                lastRescueTime = Time.time;
                immotalTime = Time.time;
            }
            else if (!otherDeath && !gameOver && (Time.time < lastRescueTime + 5.0f))
                Debug.Log($"{5 + lastRescueTime - Time.time} seconds later");
        }

        if (other.gameObject.name is "Zone_South" && PlayerDeath)
        {
            gameOver = true;
        }



    }

    private void Update()
    {
        if (PlayerDeath)
        {
            tr.Translate(new Vector3(0, -0.04f, -0.1f));
        }
    }


    void Destroyed()
    {
        curPlayerHealth = 0.0f;
        PlayerDeath = true;
        needRescue.material.color = new Color(1, 0, 0, 1);
        PlayerMove.enabled = false;
        smoke.Play();
        fireEffect.Stop();
        shotPos.SetActive(false);
    }
    void Repaired()
    {
        curPlayerHealth = 1.0f;
        PlayerDeath = false;
        needRescue.material.color = new Color(0.5882f, 0.5882f, 0.5882f, 1);
        PlayerMove.enabled = true;
        smoke.Stop();
        repairParticle.Play();
        shotPos.SetActive(true);
    }

}
