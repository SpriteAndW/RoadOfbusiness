using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntimacyWindow : UIFunctionWindow
{
    public Transform grid;
    // public Scrollbar scroB;
    public void Refresh()
    {
        // scroB.value = 1;
        for (int i = 0; i < grid.childCount; i++)
        {
            grid.GetChild(i).GetComponent<IntimacyColumn>().Refresh();
        }
        
    }
}
