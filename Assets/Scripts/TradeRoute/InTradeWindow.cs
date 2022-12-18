using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InTradeWindow : UIWindows
{
    public GameObject intradePrefab;
    public Transform grid;
    // public Scrollbar scrob;
    private void Start()
    {
        GetUIeventhandler("Close").PointerClick += Close;
    }

    private void Close(PointerEventData eventData)
    {
        SetVisible(false);
        for (int i = 0; i < grid.childCount; i++)
        {
            Destroy(grid.GetChild(i).gameObject);
        }
    }

    public void Refresh()
    {
        //根据玩家买了的地刷新已有的UI
        for (int i = 0; i < Business.Instance.myLand.Count; i++)
        {
            GameObject intrade = Instantiate(intradePrefab, grid);
            intrade.GetComponent<InTraedMap>().gridInfo = Business.Instance.myLand[i];
        }
        // scrob.value = 1;
        
    }
}
