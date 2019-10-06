using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    //Ref zu Audiodatteien
    public AudioClip crashSound;
    public AudioClip successSound;
    public AudioClip idleSound;
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
        source.loop = false;
        source.clip = crashSound;
        source.PlayOneShot(source.clip);
        //Warten bis der Sound zuende ist
        StartCoroutine(WaitForSoundFinish(crashSound.length, true));           
    }

    public void PlaySuccess() {
        source.loop = false;
        source.clip = successSound;
        source.PlayOneShot(source.clip);
        //Warten bis der Sound zuende ist
        StartCoroutine(WaitForSoundFinish(successSound.length, false));
      
    }

    public void PlayIdle() {
        //Audio Loopen und abspielen
        if (!source.isPlaying) {
            source.volume = 0.25f;
            source.clip = idleSound;
            source.loop = true;
            source.Play();
        }
    }

    public void StopIdle() {
        source.loop = false;
        source.Stop();
    }

    IEnumerator WaitForSoundFinish(float length, bool fail)
    {
        yield return new WaitForSeconds(length);
        Util.LoadLevel(fail);
        
    }
}
