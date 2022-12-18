using System;
using System.Collections;
using System.Collections.Generic;
using Tool;
using UnityEngine;
using UnityEngine.EventSystems;

public class BankButton : MonoBehaviour
{
    public BankUI bankW;
    void Start()
    {
        GetComponent<UIEventHandler>().PointerClick += ShopWindowVis;
        Camera.main.GetComponent<AnimationEventbehavior>().OnAnimationEnd += Test;
    }

    private void ShopWindowVis(PointerEventData eventData)
    {
        Camera.main.GetComponent<Animator>().SetBool("Bank", true);
    }
    private void Test()
    {
        bankW.SetVisible(true);
        Camera.main.GetComponent<Animator>().SetBool("Bank", false);
    }

}