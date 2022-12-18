using System;
using System.Collections;
using System.Collections.Generic;
using Tool;
using UnityEngine;
using UnityEngine.EventSystems;

public class TradeButton : MonoBehaviour
{
    public TradeRouteWindow tradeW;
    void Start()
    {
        GetComponent<UIEventHandler>().PointerClick += Bank;
        Camera.main.GetComponent<AnimationEventbehavior>().OnAnimationEnd += Test;
    }


    private void Bank(PointerEventData eventData)
    {

        Camera.main.GetComponent<Animator>().SetBool("Trade", true);


    }
    private void Test()
    {
        tradeW.SetVisible(true);
        Camera.main.GetComponent<Animator>().SetBool("Trade", false);
    }
}
