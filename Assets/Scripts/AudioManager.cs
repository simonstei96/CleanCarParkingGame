﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip crashSound;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source.clip = crashSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCrash()
    {
        source.Play();
       
        
    }
}