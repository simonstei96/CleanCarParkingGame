using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour
{
    
    public Rigidbody2D car;
    public float acceleration=10f;
    public float velo=0;

    public float maxSpeed = 50f;
    public float currentX = 0;
    public float currentY = 0;
    public float rot = 0;
    private bool drive = false;
    private bool reverse = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        //Accelerometer Input
        Vector3 accMeter = Input.acceleration;
        // Get input
      //  float h = -Input.GetAxis("Horizontal");
     //   float v = Input.GetAxis("Vertical");
        float h = -Mathf.Clamp(accMeter.x, -1, 1);
        float v = -Mathf.Clamp(accMeter.z, -1 , 1);

       

        h = roundHelper(h);
        v = roundHelper(v);
      //  Vector2 dir = new Vector2(v, h);

        //Debugging
        currentX = car.velocity.x;
        currentY = car.velocity.y;
        rot = car.rotation;

/*
        //Accelerate
        //Ausgleich ,da es schwierig ist, Tablet auf 0 Balance zu halten
        if (v >= 0.1f || v <= -0.1f)
            velo += acceleration * v*2 *Time.deltaTime;
        //Clamp Max Speed
        if (velo > maxSpeed || velo < -maxSpeed)
            velo = maxSpeed * Mathf.Sign(velo);
        //Decelerate
        if (v < 0.1f && v > -0.1f)
            velo = 0;
            */

        if(drive)
            velo += acceleration * Time.deltaTime;
        if(reverse)
            velo -= acceleration * Time.deltaTime;
        if (!drive && !reverse)
            velo = 0;
        if (velo > maxSpeed || velo < -maxSpeed)
            velo = maxSpeed * Mathf.Sign(velo);

        //Apply Force to Move rigidbody
        Vector2 moveDir = car.GetRelativeVector(Vector2.right) * velo;

        Debug.Log("OUTPUT:  velo: "+velo);
        //Rotationszeug
        if (velo > 8 || velo < -8)
        {
            //Aenderung klein halten am Anfang
            if (velo > 0)
                car.MoveRotation(car.rotation + (h));
            else
                car.MoveRotation(car.rotation - (h));

        }
        else
        {
            if (velo > 2 || velo < -2)
            {
                //Aenderung klein halten am Anfang
                if (velo > 0)
                    car.MoveRotation(car.rotation + (h/8));
                else
                    car.MoveRotation(car.rotation - (h/8));

            }
        }

        car.AddForce(moveDir);
        

    }

    public void Vorwaerts()
    {
        drive = true;
     
    }

    public void Rueckwaerts()
    {
        reverse = true;
    }

    public void StopCar()
    {
        drive = false;
        reverse = false;
    }

    //Helperfkt
    private float roundHelper(float value)
    {
        return (Mathf.Round(value * 100f) / 100f);
    }

}
