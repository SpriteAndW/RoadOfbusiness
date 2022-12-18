using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HelpWindow : UIWindows
{
    public Transform selectPanel;
    public Sprite beforeS;
    public Sprite afterS;

    private void Start()
    {
        GetUIeventhandler("Close").PointerClick += IntroduceWindowClose;
    }

    private void IntroduceWindowClose(PointerEventData eventData)
    {
        SetVisible(false);
    }

    public void SelectShop()
    {
        selectPanel.GetChild(0).GetComponent<Image>().sprite = afterS;
        selectPanel.GetChild(1).GetComponent<Image>().sprite = beforeS;
        selectPanel.GetChild(2).GetComponent<Image>().sprite = beforeS;
    }

    public void SelectTrade()
    {
        selectPanel.GetChild(0).GetComponent<Image>().sprite = beforeS;
        selectPanel.GetChild(1).GetComponent<Image>().sprite = afterS;
        selectPanel.GetChild(2).GetComponent<Image>().sprite = beforeS;
    }

    public void SelectStore()
    {
        selectPanel.GetChild(0).GetComponent<Image>().sprite = beforeS;
        selectPanel.GetChild(1).GetComponent<Image>().sprite = beforeS;
        selectPanel.GetChild(2).GetComponent<Image>().sprite = afterS;
    }
}
