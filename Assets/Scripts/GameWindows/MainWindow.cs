using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Tool;
using UnityEngine.UI;
using DG.Tweening;

public class MainWindow : UIWindows
{
    //private Business business;
    private MapWindows map;
    private MenuWindow menu;
    private Text creditText;
    private Text wealthText;
    private Text timeText;
    private Text roundText;
    public string season;
    public static MainWindow Instance;
    public bool isOpenMenu;

    private void Start()
    {
        //business = FindObjectOfType<Business>();
        map = UIManger.Instance.Getwindows<MapWindows>();
        menu = UIManger.Instance.Getwindows<MenuWindow>();
        GetUIeventhandler("Map").PointerClick += Map;
        //GetUIeventhandler("Refresh").PointerClick += Refresh;
        SetVisible(true);
        creditText = transform.GetchildByname("CreditText").GetComponent<Text>();
        wealthText = transform.GetchildByname("WealthText").GetComponent<Text>();
        timeText = transform.GetchildByname("TimeText").GetComponent<Text>();
        roundText = transform.GetchildByname("RoundText").GetComponent<Text>();
        GetUIeventhandler("Menu").PointerClick += Menu;
        Instance = this;
    }

    private void Menu(PointerEventData eventData)
    {
        if (!isOpenMenu)
        {
            Refresh();

            menu.SetVisible(true);

            for(int i=0;i<7;i++)
            {
                menu.transform.GetChild(i).GetComponent<DOTweenAnimation>().DORestart();
            }
        }
        else
        {
            Refresh();
            menu.SetVisible(false);
        }
        isOpenMenu = !isOpenMenu;



    }




    /// <summary>
    /// ˢ�²Ƹ�������ֵ�ķ���
    /// </summary>
    /// <param name="eventData"></param>
    //private void Refresh(PointerEventData eventData)
    //{
    //    creditText.text = string.Format("����ֵ��{0}", Business.Instance.credit.ToString());
    //    wealthText.text = string.Format("�Ƹ�ֵ��{0}", Business.Instance.wealth.ToString());
    //}


    /// <summary>
    /// �򿪵�ͼ�ķ���
    /// </summary>
    /// <param name="eventData"></param>
    private void Map(PointerEventData eventData)
    {
        Refresh();
        map.SetVisible(true);
    }

    public void Refresh()
    {
        
        switch(Business.Instance.playDays % 120 / 30)
        {
            case 0:
                season = "��";
                break;
            case 1:
                season = "��";
                break;
            case 2:
                season = "��";
                break;
            case 3:
                season = "��";
                break;
            default:
                season = "��";
                break;
        }
        creditText.text = string.Format("{0}", Business.Instance.credit.ToString());
        wealthText.text = string.Format("{0}", Business.Instance.wealth.ToString());
        timeText.text = string.Format("{0}��--{1}��--{2}��",
            686 + Business.Instance.playDays / 120, season
            , Business.Instance.playDays % 30);
        roundText.text = string.Format("{0}�غ�", Business.Instance.playDays);
    }

    //private void Map()
    //{
    //    map.SetVisible(true);
    //}



}
