using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParkingSpotDetection : MonoBehaviour
{
    private int detectors;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (detectors == 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            detectors = 0; //Mybe delete that
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        detectors++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        detectors--;
    }
}
