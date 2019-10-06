
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    //Liste der Level, Basiert auf Leveleditorversuch
    List<LevelClass> levels;
    //List<Dropdown.OptionDataList> optionLevels;
    //DropdownMenu
    public Dropdown levelSelector;

    //Start selected Level in Dropdown
   public void StartGame()
    {
        //Level starten und Info speichern
        int idx = levels[levelSelector.value].getNumber();
        Data.data.startLevel = idx;
        Util.LoadLevel(idx);
    }

    //Open Story
    public void OpenStory()
    {
        //Open Scene
        
        Util.LoadScene("Story");
    }

    public void OpenSettings() {
        //Open Scene
        
        Util.LoadScene("Settings");
    }

    void Start()
    {
        //Clear items in dropdown
        levelSelector.ClearOptions();
        //Create Level List
        levels = new List<LevelClass>();
        //Set Levelanzahl
        Data.data.level = 4;
        //Create new items and add
        for(int i = 1; i <= 4; ++i)
        {
            LevelClass tmp = new LevelClass(i);
            levels.Add(tmp);
            levelSelector.options.Add((Dropdown.OptionData)tmp);
           
        }

        
    }

}
