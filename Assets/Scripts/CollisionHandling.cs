﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandling : MonoBehaviour
{
    public AudioManager audioManager;
    public CarControl control;
    private int detectors;
    // Start is called before the first frame update
    void Start()
    {
        control =  GameObject.Find("MainCar").GetComponent<CarControl>();
        if (audioManager == null)
            Debug.Log("DBG: audioManager is null");
    }

    // Update is called once per frame
    void Update()
    {
        //Ueberpruefen, ob Fahrzeug so viel wie moeglich sich im Parkplatz befindet
        if (detectors == 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            detectors = 0; //Mybe delete that
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        Debug.Log("DBG: TriggerEnter "+collision.name);
        //Ueberpruefung, ob es sich um den Zielparkplatz handelt
        if (collision.name.Equals("ParkingBox"))
            detectors++;
        else
        {
            if (!collision.name.Equals("OuterCollisionRectangle"))
                crashHappened();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Equals("ParkingBox"))
            detectors--;
        if (collision.name.Equals("OuterCollisionRectangle"))
            crashHappened();
    }

    private void crashHappened()
    {
        Debug.Log("DBG: crashHappened()");
        //Stop car
        control.SetCrashed(true);
        //Play Sound
        audioManager.PlayCrash();
        
        Debug.Log("DBG: Has waited for some seconds");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

