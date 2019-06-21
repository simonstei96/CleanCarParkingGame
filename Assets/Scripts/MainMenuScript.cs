
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
        Debug.Log("START GAME");
        SceneManager.LoadScene(levelSelector.value);
    }

    //Open Leveleditor
    public void StartEditor()
    {
        //Open Scene
        Debug.Log("LEVEL EDITOR");
        //SceneManager.LoadScene("lvlEditor");
    }

    void Start()
    {
        //Clear items in dropdown
        levelSelector.ClearOptions();
        //Create Level List
        levels = new List<LevelClass>();

        //Create new items and add
        for(int i = 0; i <= 10; ++i)
        {
            LevelClass tmp = new LevelClass(i);
            levels.Add(tmp);
            levelSelector.options.Add((Dropdown.OptionData)tmp);
        }

        
    }
}
