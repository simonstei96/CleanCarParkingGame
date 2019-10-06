using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static Data data;

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
