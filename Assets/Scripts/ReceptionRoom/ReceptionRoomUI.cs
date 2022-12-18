 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReceptionRoomUI : UIFunctionWindow
{
    public MainBranchLineWindow mainbranchW;
    public GameObject marryW;
    public BuildingsWindow buildingW;

    public GameObject ReceptionRoomGuide;

    protected override void Start()
    {
        // base.Start();
        if (PlayerPrefs.GetInt(Const.ReceptionRoomNovice, 0) == 0)
        {
            ReceptionRoomGuide.SetActive(true);
        }
    }

    public void MainLine()
    {
        mainbranchW.SetVisible(true);
        mainbranchW.Refresh(true);
    }
    public void BranchLine()
    {
        mainbranchW.SetVisible(true);
        mainbranchW.Refresh(false);
    }

    public void Marry()
    {
        marryW.gameObject.SetActive(true);

        if (DialogueManager.instance.isReceptionGuideing)
        {
            NoviceGuidePanel._instance.NextStep(ReceptionRoomGuideConst.OpenMarry);
        }
    }

    public void Buildings()
    {
        buildingW.SetVisible(true);
        buildingW.Refresh();
    }
    
    public void ReceptionRoomGuideNextStep()
    {
        Debug.Log(1);
        marryW.SetActive(false);
        
        if (DialogueManager.instance.isReceptionGuideing)
        {
            NoviceGuidePanel._instance.NextStep(ReceptionRoomGuideConst.CloseMarry);
        }
    }


    
    public void FinashGuide()
    {
        Debug.Log("完成");
        PlayerPrefs.SetInt(Const.ReceptionRoomNovice, 1);
    }

    public void BakeMainScene()
    {
        EventHandler.CallAfterSceneLoadeEvent("MainScene");
        // SceneManager.LoadScene("MainScene");
    }
}
