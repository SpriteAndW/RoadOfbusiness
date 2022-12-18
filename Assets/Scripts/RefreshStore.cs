using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Tool;

public class RefreshStore : MonoBehaviour
{

    public StoreWindow storeW;
    void Start()
    {
        storeW = UIManger.Instance.Getwindows<StoreWindow>();
        GetComponent<UIEventHandler>().PointerClick += RefreshStoreBut;
        Camera.main.GetComponent<AnimationEventbehavior>().OnAnimationEnd += Test;
    }

    private void RefreshStoreBut(PointerEventData eventData)
    {
        
        Camera.main.GetComponent<Animator>().SetBool("Move", true);
        

    }
    private void Test()
    {
        storeW.SetVisible(true);
        storeW.Refresh();
        Camera.main.GetComponent<Animator>().SetBool("Move", false);
    }
}
