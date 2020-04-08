using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItem : MonoBehaviour
{
    float MoveSpeed = 10.0f;

    GameObject item;

    private AudioSource myaudio;

    // Start is called before the first frame update
    void Start()
    {
        item = transform.gameObject;

        myaudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Boxmove();
    }
    
    void Boxmove()
    {
        float zMove = MoveSpeed * Time.deltaTime;
        transform.Translate(0, 0, zMove);

        Destroy(item, 7.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            myaudio.Play();
            
        }
    }

}
