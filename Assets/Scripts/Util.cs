using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Util : MonoBehaviour
{
    public void Back() {
        //SceneManager.LoadScene("MainMenu");
        LoadScene("MainMenu");
    }

    public static void LoadLevel(int idx) {
        SceneManager.LoadScene(3 + idx);
    }

    public static void LoadLevel(bool failedLevel) {

        bool state = Data.data.hardMode;
        if (state) {
            if (failedLevel) {
                Data.data.doneLevel = 0;
                Util.LoadLevel(Data.data.startLevel);
            }
            else {
                if (Data.data.startLevel + Data.data.doneLevel > Data.data.level)
                    Util.LoadScene("FinalScene");
                else
                    Util.LoadLevel(Data.data.startLevel + Data.data.doneLevel);
            }
        }
        else {
            if (failedLevel)
                Util.LoadLevel(Data.data.startLevel + Data.data.doneLevel);
            else {
                if (Data.data.startLevel + Data.data.doneLevel > Data.data.level)
                    Util.LoadScene("FinalScene");
                else
                    Util.LoadLevel(Data.data.startLevel + Data.data.doneLevel);
            }

        }
    }

    public static void LoadScene(string name) {
        SceneManager.LoadScene(name);
    }
}
