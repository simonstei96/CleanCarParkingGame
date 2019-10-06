using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour
{
    
    public Rigidbody2D car;
    AudioManager audioMan;

    private float acceleration=10f;
    private float velo=0;

    private float maxAngle = 33.5f;
    private float maxSpeed = 50f;
    private float rot = 0;

    private bool drive = false;
    private bool reverse = false;
    private bool stop = false;
    // Start is called before the first frame update
    void Start()
    {
        audioMan = GameObject.Find("AudioUnit").GetComponent<AudioManager>();
        
    }
    void FixedUpdate()
    {
        //If car has crashed, do not move
        if (stop)
        {      
            car.velocity = new Vector2(0, 0);
            return;
        }

        //Accelerometer Input
        Vector3 accMeter = Input.acceleration;
        // Get input
        float h = -Mathf.Clamp(accMeter.x, -1, 1);
        h = roundHelper(h);


        //Accelerate(forward)
        if (drive) {           
            velo += acceleration * Time.deltaTime;
        }
        //Accelerate(backward)
        if (reverse) {
           
            velo -= acceleration * Time.deltaTime;
        }

        //Max Speed einhalten
        if (Mathf.Abs(velo) > maxSpeed) {
            velo = maxSpeed * Mathf.Sign(velo);
        }
        //Decelartion
        if (!drive && !reverse){
            
            //Check, if car was moving forward/backward
            if (velo > 0){
                velo -= 4.5f*acceleration * Time.deltaTime;
                //Ueberschreiten des Abbremsvorgangs verhindern
                if (velo < 0) {
                    velo = 0;
                    audioMan.StopIdle();
                }
            }
            else{
                if (velo < 0) {
                    velo += 4.5f*acceleration * Time.deltaTime;
                    //Ueberschreiten des Abbremsvorgangs verhindern
                    if (velo > 0) {
                        velo = 0;
                        audioMan.StopIdle();
                    }
                }
            }
        }
       

        rot = Mathf.Sign(velo)* velo*1.5f * h*Time.deltaTime;
        if (rot > maxAngle)
            rot = maxAngle * Mathf.Sign(rot);
 
        //Rotation anwenden
        if (velo > 5)
        {
            car.MoveRotation(car.rotation + rot );
        }
        else
        {
            if (velo < -5)
                car.MoveRotation(car.rotation - rot);
        }
        

        //Apply Force to Move rigidbody
        Vector2 moveDir = car.GetRelativeVector(Vector2.right) * velo;
        car.AddForce(moveDir);

      
    }

    //Controls (left)
    public void Vorwaerts()
    {
        //Car Sound
        audioMan.PlayIdle();

        if (Data.data.invertedControls == true)
            drive = true;
        else
            reverse = true;
    }

    //Controls(right)
    public void Rueckwaerts()
    {
        //Car Sound
        audioMan.PlayIdle();

        if (Data.data.invertedControls == true)
            reverse = true;
        else
            drive = true;
    }
    //Controls(no input)
    public void StopCar()
    {
     
        drive = false;
        reverse = false;
    }

    public void StopMovement(bool state)
    {
        stop = state;
    }

    //Helperfkt
    private float roundHelper(float value)
    {
        return (Mathf.Round(value * 100f) / 100f);
    }

}
