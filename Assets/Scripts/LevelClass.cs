using System.Collections.Generic;
using UnityEngine.UI;

public class LevelClass: Dropdown.OptionData
{
    //Level name to be displayed
    private string name;

    //Constructor with base call in Dropdown.OptionsData
    public LevelClass(string s): base(s)
    {     
        this.name = s;
    }

    public string getName()
    {
        return name;
    }
}
