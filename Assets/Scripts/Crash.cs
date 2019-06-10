using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
    public AudioManager AudioMan;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Play Sound
        AudioMan.PlayCrash();
        //Restart or start failed level scene
        while (AudioMan.source.isPlaying) { }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
