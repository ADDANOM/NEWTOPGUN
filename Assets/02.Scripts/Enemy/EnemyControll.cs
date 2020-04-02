using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    //public ParticleSystem ExPlosion;
    public float moveSpeed = 10.0f;  // EnenmyMove 속도값.

    public float curHealth = 100.0f;
    public bool isAlive = true;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnenmyMove();
    }

    private void OnTriggerEnter(Collider coll)
    {
        
        //ExPlosion.gameObject.SetActive(true);  // 체력이 다했을 때로 발생하도록 수정필요!
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("Destroy");
            Destroy(this.gameObject);
        }
    }

    void EnenmyMove()
    {
        float zMove = (moveSpeed * Time.deltaTime);
        transform.Translate(0, 0, zMove);
    }

    
}
