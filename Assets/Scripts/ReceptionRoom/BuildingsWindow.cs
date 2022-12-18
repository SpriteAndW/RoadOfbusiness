using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildingsWindow : UIWindows
{
    public BuildingsUI bu;
    // Start is called before the first frame update
    private void Start()
    {
        GetUIeventhandler("Close").PointerClick += Close;
    }

    private void Close(PointerEventData eventData)
    {
        SetVisible(false);
    }

    public void Close()
    {
        SetVisible(false);
    }

    public void Refresh()
    {
        GameObject bP= this.transform.GetChild(0).GetChild(0).gameObject;
        GameObject aP= this.transform.GetChild(0).GetChild(1).gameObject;
        if (BuildingsManager.Instance.buildingType == 0)
        {
            bP.SetActive(true);
            aP.SetActive(false);
        }
        else
        {
            bP.SetActive(false);
            aP.SetActive(true);
            bu.OpenInformationPanel();
        }
    }
    
}
