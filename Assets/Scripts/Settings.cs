using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Settings : MonoBehaviour
{
    //Speichern des Steuerungseinstellung
    public void ChangedControls(bool state) {
        Data.data.invertedControls = state;
    }
    //Speichern der Schwierigkeitsstufe
    public void ChangedMode(bool state) {
        Data.data.hardMode = state;
        
    }
}
