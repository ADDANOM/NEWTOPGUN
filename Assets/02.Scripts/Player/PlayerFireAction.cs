﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireAction : MonoBehaviour
{
    public AudioClip clip;
    AudioSource _audio;

    private void OnEnable()
    {
        _audio = GetComponent<AudioSource>();
        _audio.clip = clip;
        _audio.Play();
    }

    void Update()
    {
        this.transform.Translate(Vector3.forward * 400.0f * Time.deltaTime);
    }

}
