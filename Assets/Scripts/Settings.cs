using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Settings : MonoBehaviour
{
    public void ChangedControls(bool state) {
        Data.data.invertedControls = state;
    }

    public void ChangedMode(bool state) {
        Data.data.hardMode = state;
        
    }
}
