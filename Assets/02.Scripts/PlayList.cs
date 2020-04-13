using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayList : MonoBehaviour
{
    AudioSource mySource;
    public AudioClip[] myClip;

    void Start()
    {
        mySource = GetComponent<AudioSource>();

        mySource.clip = myClip[0];
        mySource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        PlayLists();
    }

    void PlayLists()
    {

        if (!mySource.isPlaying)
        {
            mySource.clip = myClip[1];
            mySource.Play();
            mySource.loop = true;
        }
    }
}
