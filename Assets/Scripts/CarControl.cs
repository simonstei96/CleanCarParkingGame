using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour
{
    
    public Rigidbody2D car;
    public float acceleration=10f;
    public float velo=0;

    public float maxSpeed = 50f;
    public float maxAngle = 33.5f;
    public float currentX = 0;
    public float currentY = 0;
    public float rot = 0;
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
      //  float v = -Mathf.Clamp(accMeter.z, -1 , 1);

        h = roundHelper(h);
      

        //Debugging
        currentX = car.velocity.x;
        currentY = car.velocity.y;
        //rot = car.rotation;


        if(drive)
            velo += acceleration * Time.deltaTime;
        if(reverse)
            velo -= acceleration * Time.deltaTime;
        if (!drive && !reverse)
            velo = 0;
        if (velo > maxSpeed || velo < -maxSpeed)
            velo = maxSpeed * Mathf.Sign(velo);




        //Rotationszeug
        if (velo > 40 || velo < -40)
        {
            rot = maxAngle * h * Time.deltaTime;
        }
        else {
            if (velo > 8 || velo < -8)
            {
                rot = (maxAngle/2f) * h * Time.deltaTime;
            }
            else
            {
                rot = 0;
            }
        }
       
        //Max Lenkeinstellung einhalten
        //  if (rot > maxAngle || rot < -maxAngle)
        //     rot = maxAngle * Mathf.Sign(rot);
        //Rotation anwenden
        Debug.Log("DBG: velo/rot value: " + velo+":-: "+rot);
        if (velo > 8)
        {
            car.MoveRotation(car.rotation + rot );
        }
        else
        {
            if (velo < -8)
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
