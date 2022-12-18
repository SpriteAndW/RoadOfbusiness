using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopsWindow : UIFunctionWindow
{
    public OpenShopsWindow shopW;
    public BankruptcyWindow bankW;

    [Header("引导系统")] public GameObject ShopGuideTipPanel;
    protected override void Start()
    {
        base.Start();
        // GetComponentsInChildren<Button>()[0].onClick.AddListener(OpenShopWindow);
        // GetComponentsInChildren<Button>()[1].onClick.AddListener(OpenBankruptcyWindow);
        //shopW = UIManger.Instance.Getwindows<OpenShopsWindow>();
        //bankW = UIManger.Instance.Getwindows<BankruptcyWindow>();
        
        
        if (PlayerPrefs.GetInt(Const.ShopNovice, 0) == 0)
        {
            ShopGuideTipPanel.SetActive(true);
        }
    }

    public void OpenBankruptcyWindow()
    {
        bankW.SetVisible(true);
        bankW.Refresh();
    }

    public void OpenShopWindow()
    {
        // shopW.SetVisible(true);
        shopW.gameObject.SetActive(true);
        shopW.Refresh();
        
        if (DialogueManager.instance.isShopGuideing)
        {
            NoviceGuidePanel._instance.NextStep(ShopGuideConst.OpenShop);
        }
    }

    public void FinashGuide()
    {
        PlayerPrefs.SetInt(Const.ShopNovice, 1);
    }
    public void BakeMainScene()
    {
        EventHandler.CallAfterSceneLoadeEvent("MainScene");
        // SceneManager.LoadScene("MainScene");
    }
}
