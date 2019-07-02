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
        source.PlayOneShot(source.clip);
        StartCoroutine(WaitForSoundFinish(crashSound.length, true));
            
    }

    public void PlaySuccess() {
        source.clip = successSound;
        source.PlayOneShot(source.clip);
        StartCoroutine(WaitForSoundFinish(successSound.length, false));
    }

    IEnumerator WaitForSoundFinish(float length, bool fail)
    {
        yield return new WaitForSeconds(length);
        if(fail)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
