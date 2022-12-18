using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainBranchLineWindow : UIWindows
{
    public GameObject eventPrefab;
    public Transform grid;
    // public Scrollbar scrob;
    private void Start()
    {
        GetUIeventhandler("Close").PointerClick += Close;
    }

    private void Close(PointerEventData eventData)
    {
        for (int i = 0; i < grid.childCount; i++)
        {
            Destroy(grid.GetChild(i).gameObject);
        }
        SetVisible(false);
    }

    //是主线还是支线

    public void Refresh(bool isMainLine)
    {
        if (isMainLine)
        {
            for (int i = 0; i < DialogueManager.instance.MainDoneDialogue.Count; i++)
            {
                GameObject plot = Instantiate(eventPrefab, grid);
                plot.GetComponent<PlotRecord>().dialogD = DialogueManager.instance.MainDoneDialogue[i];
                plot.GetComponent<PlotRecord>().Init();
            }
        }
        else
        {
            for (int i = 0; i < DialogueManager.instance.BranchDoneDialogue.Count; i++)
            {
                GameObject plot = Instantiate(eventPrefab, grid);
                plot.GetComponent<PlotRecord>().dialogD = DialogueManager.instance.BranchDoneDialogue[i];
                plot.GetComponent<PlotRecord>().Init();
            }
        }
        // scrob.value = 1;

    }
}
