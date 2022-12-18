using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettleWindow : UIWindows
{
    
    public SleepWindow sleepW;
    //对象
    public static SettleWindow Instance;
    //昨天的财富值
    public float yesWealth;
    //昨天的信用值
    public float yesCredit;

    private void Start()
    {
        Instance = this;
        GetUIeventhandler("Close").PointerClick += CloseSettle;
        
    }

    private void CloseSettle(PointerEventData eventData)
    {
        SetVisible(false);
        //加载睡觉窗口 播放动画完毕后关闭
        sleepW.SetVisible(true);
        sleepW.transform.GetChild(1).gameObject.SetActive(true);
        sleepW.transform.GetChild(0).gameObject.SetActive(true);
        Invoke("CloseSleep", 2);
    }

    public void CloseSleep()
    {
        sleepW.SetVisible(false);
        sleepW.transform.GetChild(1).gameObject.SetActive(false);
        sleepW.transform.GetChild(0).gameObject.SetActive(false);
        //判断剧情触发
        SleepDialogueEvent.Instance.DialogueEvent();
        SceneManager.LoadScene("MainScene");
    }
    //每日结算评价等级
    public Text levelText;
    //每日结算文本框
    public Text settleText;

    //记录去过的地方
    public List<string> sceneName = new List<string>();


    //记录倒闭的店铺
    public List<string> bankruptcyShopName = new List<string>();

    public void RefreshText()
    {
        settleText.text = "";
        bankruptcyShopName.Clear();
        sceneName.Clear();
        levelText.color = new Vector4(0, 0, 0, 0);
    }
    public void Refresh()
    {
        if(sceneName.Count > 0)
        {
            settleText.text += "今天你去过这些地方:";
            for (int i = 0; i < sceneName.Count; i++)
            {
                settleText.text += sceneName[i] + "  "; 
            }
            settleText.text += "\n";
        }

        if(bankruptcyShopName.Count > 0)
        {
            settleText.text += "今天 ";
            for (int i = 0; i < bankruptcyShopName.Count; i++)
            {
                settleText.text += bankruptcyShopName[i] + " ";
            }
            settleText.text += "倒闭了,扣除了" + (bankruptcyShopName.Count * 2).ToString() + "信用值\n";
           
        }
        if (SettleWindow.Instance.settleText.text == "")
        {
            

            Sequence sequence = DOTween.Sequence();
            sequence.Append(settleText.DOText("今天是平静的一天\n" + "财富值变化为: " +
                ((int)(Business.Instance.wealth - yesWealth)).ToString() + "\n" +
                "信用值变化为: " + (Business.Instance.credit - yesCredit).ToString(), 2f));
            //sequence.Append(levelText.DOColor(Color.red, 0.1f));
            sequence.Append(levelText.transform.DOScale(new Vector3(3f, 3f, 3f), 1f));
            sequence.Append(levelText.transform.DORotate(new Vector3(0, 0, 180), 0.05f));
            sequence.Append(levelText.transform.DORotate(new Vector3(0, 0, 360), 0.05f));
            sequence.Append(levelText.transform.DORotate(new Vector3(0, 0, 180), 0.05f));
            sequence.Append(levelText.transform.DORotate(new Vector3(0, 0, 360), 0.05f));
            sequence.Append(levelText.transform.DORotate(new Vector3(0, 0, 180), 0.05f));
            sequence.Append(levelText.transform.DORotate(new Vector3(0, 0, 360), 0.05f));
            sequence.Append(levelText.transform.DORotate(new Vector3(0, 0, 180), 0.05f));
            sequence.Append(levelText.transform.DORotate(new Vector3(0, 0, 360), 0.05f));
            sequence.Append(levelText.transform.DORotate(new Vector3(0, 0, 180), 0.05f));
            sequence.Append(levelText.transform.DORotate(new Vector3(0, 0, 370), 0.05f));
            sequence.Append(levelText.transform.DOScale(new Vector3(1f, 1f, 1f), 0.1f));
            sequence.Play();
            yesCredit = Business.Instance.credit;
            yesWealth = Business.Instance.wealth;
        }
        else
        {
            

            Sequence sequence = DOTween.Sequence();
            sequence.Append(settleText.DOText(settleText.text + "财富值变化为: " +
                ((int)(Business.Instance.wealth - yesWealth)).ToString() + "\n" +
                "信用值变化为: " + (Business.Instance.credit - yesCredit).ToString(), 5f));
            sequence.Append(levelText.DOColor(Color.red, 0.1f));
            sequence.Append(levelText.transform.DOScale(new Vector3(3f, 3f, 3f), 1f));
            sequence.Append(levelText.transform.DORotate(new Vector3(0, 0, 180), 0.05f));
            sequence.Append(levelText.transform.DORotate(new Vector3(0, 0, 360), 0.05f));
            sequence.Append(levelText.transform.DORotate(new Vector3(0, 0, 180), 0.05f));
            sequence.Append(levelText.transform.DORotate(new Vector3(0, 0, 360), 0.05f));
            sequence.Append(levelText.transform.DORotate(new Vector3(0, 0, 180), 0.05f));
            sequence.Append(levelText.transform.DORotate(new Vector3(0, 0, 360), 0.05f));
            sequence.Append(levelText.transform.DORotate(new Vector3(0, 0, 180), 0.05f));
            sequence.Append(levelText.transform.DORotate(new Vector3(0, 0, 360), 0.05f));
            sequence.Append(levelText.transform.DORotate(new Vector3(0, 0, 180), 0.05f));
            sequence.Append(levelText.transform.DORotate(new Vector3(0, 0, 370), 0.05f));
            sequence.Append(levelText.transform.DOScale(new Vector3(1f, 1f, 1f), 0.1f));
            sequence.Play();
            yesCredit = Business.Instance.credit;
            yesWealth = Business.Instance.wealth;

        }


    }
}
