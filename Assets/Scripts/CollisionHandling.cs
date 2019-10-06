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
        //Ref zu Auto
        control =  GameObject.Find("MainCar").GetComponent<CarControl>();
        
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
            //Zielparkplatz erreicht
            Data.data.doneLevel++;
            control.StopMovement(true);
            audioManager.PlaySuccess();
          
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
    
        //Stop car
        control.StopMovement(true);
        //Play Sound
        audioManager.PlayCrash();
        
    }
}

