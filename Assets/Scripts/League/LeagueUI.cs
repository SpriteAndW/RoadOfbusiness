using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeagueUI : MonoBehaviour
{
    public Button openBtn;
    public Text tipText;
    

    public GameObject leguePanle;
    public Text legueText;
    public Text wealthNeedText;
    public Text creditNeedText;
    public Text shopOfferText;
    public Text shopNumText;
    public Text waysOfferText;
    public Text otherWaysOfferText;
    public Text goodsOfferText;

    private int currentLegue;


    private void Start()
    {
        UpdateLegueDetail(0);
    }


    public void UpdateLegueDetail(int btnNum)
    {
        if (btnNum == 1)
        {
            legueText.text = "老表同乡会";
            wealthNeedText.text = "信用:60";
            creditNeedText.text = "财富:100000";
            shopOfferText.text = "古玩店";
            shopNumText.text = "5";
            waysOfferText.text = "2";
            otherWaysOfferText.text = "-1";
            goodsOfferText.text = "-1";
            currentLegue = 1;
        }
        else if (btnNum == 2)
        {
            legueText.text = "金字商会";
            wealthNeedText.text = "信用:70";
            creditNeedText.text = "财富:1000000";
            shopOfferText.text = "古玩店,粮店";
            shopNumText.text = "10";
            waysOfferText.text = "5";
            otherWaysOfferText.text = "1";
            goodsOfferText.text = "1";
            currentLegue = 2;
        }
        else if (btnNum == 3)
        {
            legueText.text = "钙帮";
            wealthNeedText.text = "信用:80";
            creditNeedText.text = "财富:800000";
            shopOfferText.text = "古玩店,粮店";
            shopNumText.text = "15";
            waysOfferText.text = "10";
            otherWaysOfferText.text = "3";
            goodsOfferText.text = "5";
            currentLegue = 3;
        }
        else
        {
            legueText.text = String.Empty;
            wealthNeedText.text = String.Empty;
            creditNeedText.text = String.Empty;
            shopOfferText.text = String.Empty;
            shopNumText.text = String.Empty;
            waysOfferText.text = String.Empty;
            otherWaysOfferText.text = String.Empty;
            goodsOfferText.text = String.Empty;
        }
    }

    public void OpenAndClose(bool isOpen)
    {
        openBtn.gameObject.SetActive(!isOpen);
        leguePanle.SetActive(isOpen);
        UpdateLegueDetail(0);
    }

    public void JoinLeagueBtn()
    {
        if (currentLegue != 0)
        {
            if (Business.Instance.currentJoinLeague != 0)
            {
                tipText.gameObject.GetComponent<CanvasGroup>().alpha = 1;
                tipText.text = "请先退出当前商盟才能加入其他商盟";
                tipText.gameObject.GetComponent<CanvasGroup>().DOFade(0, 3);
            }
            else
            {
                if (currentLegue==1)
                {
                    if (Business.Instance.wealth>=100000 && Business.Instance.credit>=60)
                    {
                        Business.Instance.currentJoinLeague = currentLegue;
            
                        ShowTipText("加入商盟成功");
                    }
                    else
                    {
                        ShowTipText("加入失败,没有满足需求");
                    }
                }
                else if (currentLegue == 2)
                {
                    if (Business.Instance.wealth>=1000000 && Business.Instance.credit>=70)
                    {
                        Business.Instance.currentJoinLeague = currentLegue;
            
                        ShowTipText("加入商盟成功");
                    }
                    else
                    {
                        ShowTipText("加入失败,没有满足需求");
                    }
                }
                else if (currentLegue == 3)
                {
                    if (Business.Instance.wealth>=8000000 && Business.Instance.credit>=80)
                    {
                        Business.Instance.currentJoinLeague = currentLegue;
            
                        ShowTipText("加入商盟成功");
                    }
                    else
                    {
                        ShowTipText("加入失败,没有满足需求");
                    }
                }
            
            }
        }
    }

    public void QuitLeagueBtn()
    {
        if (Business.Instance.currentJoinLeague!=0)
        {
            Business.Instance.currentJoinLeague = 0;
            ShowTipText("退出商盟成功");

            
        }
        else
        {
            ShowTipText("当前没有加入商盟");
        }
    }

    private void ShowTipText(string s)
    {
        tipText.gameObject.GetComponent<CanvasGroup>().alpha = 1;
        tipText.text =s;
        tipText.gameObject.GetComponent<CanvasGroup>().DOFade(0, 2);
    }

    public void BackMainScene()
    {
        EventHandler.CallAfterSceneLoadeEvent("MainScene");
    }


}