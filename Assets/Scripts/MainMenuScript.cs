
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    List<LevelClass> levels;
    //List<Dropdown.OptionDataList> optionLevels;

    public Dropdown levelSelector;
    //Start selected Level in Dropdown
   public void StartGame()
    {
        //Open Scene
        int idx = levels[levelSelector.value].getNumber();
        Data.data.startLevel = idx;
        //SceneManager.LoadScene(3 + idx);
        Util.LoadLevel(idx);
    }

    //Open Story
    public void OpenStory()
    {
        //Open Scene
        //SceneManager.LoadScene("Story");
        Util.LoadScene("Story");
    }

    public void OpenSettings() {
        //Open Scene
        //SceneManager.LoadScene("Settings");
        Util.LoadScene("Settings");
    }

    void Start()
    {
        //Clear items in dropdown
        levelSelector.ClearOptions();
        //Create Level List
        levels = new List<LevelClass>();
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
