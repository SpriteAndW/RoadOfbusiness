using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



/// <summary>
/// 功能管理器
/// 条件：  1、物体必须要有碰撞器 2D.3D的都可以
///        2、相机必须要有射线检测 要和碰撞器对应
///        3、物体必须要有UIEventHandler组件
///        
/// </summary>
public class FunctionManger : MonoBehaviour
{
    GameObject[] menu;
    private void Start()
    {
        menu = GameObject.FindGameObjectsWithTag("Menu");
        
        foreach (var item in menu)
        {
            //print(item.name);

            item.GetComponent<UIEventHandler>().PointerClick += PushUIWindowByTargetName;
        }
    }

    //根据点击的物体的名字弹出UI
    private void PushUIWindowByTargetName(PointerEventData eventData)
    {
        print(eventData.pointerClick.name);
        UIWindows ui = UIManger.Instance.Getwindows<UIWindows>
            (eventData.pointerClick.name + "Window");
        ui.SetVisible(true);
    }
}
