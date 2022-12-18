using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tool;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class TaskWindow : UIWindows
{
    // public Scrollbar scroB;
    
    private void Start()
    {
        GetUIeventhandler("Close").PointerClick += TaskWindowClose;
    }

    private void TaskWindowClose(PointerEventData eventData)
    {
        SetVisible(false);
        for (int i = 0; i < grid.childCount; i++)
        {
            Destroy(grid.GetChild(i).gameObject);
        }
    }

    public Transform grid;
    public GameObject taskPrefab;

    public void Refresh()
    {
        
        for (int i = 0; i < Business.Instance.tradeDele.Count; i++)
        {
            Task task = Instantiate(taskPrefab, grid).GetComponent<Task>();
            task.dele = Business.Instance.tradeDele[i];
            task.UpdateDescription();
        }
        // scroB.value = 1;
    }
}
