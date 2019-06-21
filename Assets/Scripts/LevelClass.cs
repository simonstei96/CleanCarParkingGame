using System.Collections.Generic;
using UnityEngine.UI;

public class LevelClass: Dropdown.OptionData
{
    //Level name to be displayed
    private int idx;

    //Constructor with base call in Dropdown.OptionsData
    public LevelClass(int i) : base(i.ToString())
    {     
        this.idx = i;
    }

    public int getNumber()
    {
        return idx;
    }
}
