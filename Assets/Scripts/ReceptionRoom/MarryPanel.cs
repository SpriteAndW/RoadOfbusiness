using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MarryPanel : MonoBehaviour
{
    public Marrier marrier;
    public Button tipsBut;
    public Button giftsBut;
    public Button marryBut;
    public float tipPrice;
    public Image face;
    public GiftPanel giftP;

    public void Refresh()
    {
        face.sprite = marrier.face;
        if(marrier.father.intimacy > 10)
        {
            giftsBut.gameObject.SetActive(true);
        }
        else
        {
            giftsBut.gameObject.SetActive(false);
        }

        if(marrier.intimacy > 60)
        {
            marryBut.gameObject.SetActive(true);
        }
        else
        {
            marryBut.gameObject.SetActive(false);
        }
        this.gameObject.GetComponent<DOTweenAnimation>().DORestart();
        this.gameObject.transform.GetChild(1).GetComponent<DOTweenAnimation>().DORestart();
        this.gameObject.transform.GetChild(2).GetComponent<DOTweenAnimation>().DORestart();
    }

    public void ShowTips()
    {
        if(Business.Instance.wealth >= tipPrice)
        {
            Business.Instance.wealth -= tipPrice;
            MessageWindow.Instance.ShowMessage(marrier.Info[Random.Range(0, marrier.Info.Length)]);

        }

        else
        {
            MessageWindow.Instance.ShowMessage("钱不够哦");
        }
        
        if (DialogueManager.instance.isReceptionGuideing)
        {
            NoviceGuidePanel._instance.NextStep(ReceptionRoomGuideConst.FindNew);
        }
    }

    public void Gifts()
    {
        giftP.gameObject.SetActive(true);
        giftP.Refresh();
    }

    public void Marry()
    {
        if (Business.Instance.wife.Contains(marrier))
        {
            MessageWindow.Instance.ShowMessage("你已经迎娶了" + marrier.mName);
            return;
        }

        Business.Instance.wife.Add(marrier);
        MessageWindow.Instance.ShowMessage("恭喜你和" + marrier.mName + "结为夫妻!", marrier.face);
        marrier.intimacy = 100;
    }
}
