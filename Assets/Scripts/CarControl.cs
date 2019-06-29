using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour
{
    
    public Rigidbody2D car;
    private float acceleration=10f;
    private float velo=0;

  
    private float maxAngle = 33.5f;
    private float maxSpeed = 50f;
    private float rot = 0;

    private bool drive = false;
    private bool reverse = false;
    private bool crash = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        //If car has crashed, do not move
        if (crash)
        {
            car.velocity = new Vector2(0, 0);
            return;
        }

        //Accelerometer Input
        Vector3 accMeter = Input.acceleration;
        // Get input
        float h = -Mathf.Clamp(accMeter.x, -1, 1);
        //float v = -Mathf.Clamp(accMeter.z, -1 , 1);

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
                if (velo < 0)
                    velo = 0;
            }
            else{
                if (velo < 0) {
                    velo += 4.5f*acceleration * Time.deltaTime;
                    //Ueberschreiten des Abbremsvorgangs verhindern
                    if (velo > 0)
                        velo = 0;
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
        drive = true;
     
    }

    //Controls(right)
    public void Rueckwaerts()
    {
        reverse = true;
    }
    //Controls(no input)
    public void StopCar()
    {
        drive = false;
        reverse = false;
    }

    public void SetCrashed(bool state)
    {
        crash = state;
    }

    //Helperfkt
    private float roundHelper(float value)
    {
        return (Mathf.Round(value * 100f) / 100f);
    }

}
