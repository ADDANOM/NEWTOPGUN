using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemtyHealth : MonoBehaviour
{
    //public ParticleSystem ExPlosion;
    

    public float curHealth = 100.0f;
    public bool isAlive = true;

    
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       
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
}
