using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InTradePanel : MonoBehaviour
{
    public MapGridInfo gridInfo;

    public void Refresh()
    {
        GetComponent<Image>().sprite = gridInfo.mapimg;
        for (int i = 0; i < gridInfo.inTradeItem.Count; i++)
        {
            transform.GetChild(i).GetComponent<InTradeBoss>().boss = gridInfo.inTradeItem[i];
        }
    }
}
