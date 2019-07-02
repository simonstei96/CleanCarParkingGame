using System.Collections;
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
        //int num = PlayerPrefs.GetInt("Level:Score");
        //Debug.Log("DBG: " + num);
    }

    // Update is called once per frame
    void Update()
    {
        int num = PlayerPrefs.GetInt("Level:Score");
        Debug.Log("DBG: " + num);
        //Ueberpruefen, ob Fahrzeug so viel wie moeglich sich im Parkplatz befindet
        if (detectors == 4)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //audioManager.PlaySuccess();
            
        }
    }

    void Awake() {
        if (!PlayerPrefs.HasKey("DefaultsSet")) {
            PlayerPrefs.SetString("DefaultsSet", "True");
            PlayerPrefs.SetInt("Level:Score", 0);
   

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
   
        //Ueberpruefung, ob es sich um den Zielparkplatz handelt
        if (collision.name.Equals("ParkingBox")) {
            detectors++;
        }
        else {
       
            if (!collision.name.Equals("OuterCollisionRectangle"))
                CrashHappened();
        }
        if (detectors == 4) {
            audioManager.PlaySuccess();
            int num = PlayerPrefs.GetInt("Level:Score");
            PlayerPrefs.SetInt("Level:Score",num++);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Sollte Zielparkplatz teilweise verlassen werden
        if (collision.name.Equals("ParkingBox"))
            detectors--;
        if (collision.name.Equals("OuterCollisionRectangle"))
            CrashHappened();
    }

    private void CrashHappened()
    {
        Debug.Log("DBG: crashHappened");
        //Stop car
        control.SetCrashed(true);
        //Play Sound
        audioManager.PlayCrash();
        
    }
}

