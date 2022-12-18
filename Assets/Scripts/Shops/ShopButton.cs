using System;
using System.Collections;
using System.Collections.Generic;
using Tool;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopButton : MonoBehaviour
{
    public ShopsWindow shopW;
    void Start()
    {
        GetComponent<UIEventHandler>().PointerClick += ShopWindowVis;
        Camera.main.GetComponent<AnimationEventbehavior>().OnAnimationEnd += Test;
    }

    private void ShopWindowVis(PointerEventData eventData)
    {
        Camera.main.GetComponent<Animator>().SetBool("Shop", true);
    }
    private void Test()
    {
        shopW.SetVisible(true);
        Camera.main.GetComponent<Animator>().SetBool("Shop", false);
    }
}
