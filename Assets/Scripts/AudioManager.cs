using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip crashSound;
    public AudioClip successSound;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCrash()
    {
        source.clip = crashSound;
        source.Play();
        StartCoroutine(WaitForSoundFinish(crashSound.length));
            
    }

    public void PlaySuccess() {
        source.clip = successSound;
        source.Play();
        StartCoroutine(WaitForSoundFinish(successSound.length));
    }

    IEnumerator WaitForSoundFinish(float length)
    {
        yield return new WaitForSeconds(length);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
