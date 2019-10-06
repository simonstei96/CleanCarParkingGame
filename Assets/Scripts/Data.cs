using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    //Objekt zum kontinuierlichen Speichern der Daten in einer Session
    public static Data data;

    //Steuerung, Spielmodus, Levelinfo
    public bool invertedControls=true;
    public bool hardMode=false;
    public int level = 0;
    public int doneLevel = 0;
    public int startLevel = 0;

    void Awake() {
        if (data == null) {
            DontDestroyOnLoad(gameObject);
            data = this;
        }
        else if (data != this) {
            Destroy(gameObject);
        }
    }

    
}
