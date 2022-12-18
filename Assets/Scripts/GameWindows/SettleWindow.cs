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
    //����
    public static SettleWindow Instance;
    //����ĲƸ�ֵ
    public float yesWealth;
    //���������ֵ
    public float yesCredit;

    private void Start()
    {
        Instance = this;
        GetUIeventhandler("Close").PointerClick += CloseSettle;
        
    }

    private void CloseSettle(PointerEventData eventData)
    {
        SetVisible(false);
        //����˯������ ���Ŷ�����Ϻ�ر�
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
        //�жϾ��鴥��
        SleepDialogueEvent.Instance.DialogueEvent();
        SceneManager.LoadScene("MainScene");
    }
    //ÿ�ս������۵ȼ�
    public Text levelText;
    //ÿ�ս����ı���
    public Text settleText;

    //��¼ȥ���ĵط�
    public List<string> sceneName = new List<string>();


    //��¼���յĵ���
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
            settleText.text += "������ȥ����Щ�ط�:";
            for (int i = 0; i < sceneName.Count; i++)
            {
                settleText.text += sceneName[i] + "  "; 
            }
            settleText.text += "\n";
        }

        if(bankruptcyShopName.Count > 0)
        {
            settleText.text += "���� ";
            for (int i = 0; i < bankruptcyShopName.Count; i++)
            {
                settleText.text += bankruptcyShopName[i] + " ";
            }
            settleText.text += "������,�۳���" + (bankruptcyShopName.Count * 2).ToString() + "����ֵ\n";
           
        }
        if (SettleWindow.Instance.settleText.text == "")
        {
            

            Sequence sequence = DOTween.Sequence();
            sequence.Append(settleText.DOText("������ƽ����һ��\n" + "�Ƹ�ֵ�仯Ϊ: " +
                ((int)(Business.Instance.wealth - yesWealth)).ToString() + "\n" +
                "����ֵ�仯Ϊ: " + (Business.Instance.credit - yesCredit).ToString(), 2f));
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
            sequence.Append(settleText.DOText(settleText.text + "�Ƹ�ֵ�仯Ϊ: " +
                ((int)(Business.Instance.wealth - yesWealth)).ToString() + "\n" +
                "����ֵ�仯Ϊ: " + (Business.Instance.credit - yesCredit).ToString(), 5f));
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
