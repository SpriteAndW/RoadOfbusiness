using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tool;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class UIWindowsMerger : MonoSingleton<UIWindowsMerger>
{

    //UI窗口合并器 将所以UI窗口的生成权放在一个栏栏上 选项块

    //先获取所以UI窗口 通过一个字典

    //做一个存储UIwindowdic字典的成员变量
    Dictionary<string, UIWindows> UIwindowsDic;

    //做一个存储UIwindow按钮的字典
    Dictionary<string, GameObject> UIWindowsbuttons;

    //这是一个存储按钮对象的成员变量
    GameObject MergeButton;

    //这是存储上一个点开的窗口的成员变量
    UIWindows uiWindows;
    protected override void Init()
    {
        base.Init();
        //test
        print("nb");

        //用resourcesManger加载一下按钮
        MergeButton = ResourcesManger.Load<GameObject>("MergeButton");

        //通过UI管理器存进来
        UIwindowsDic = UIManger.Instance.UIwindowsdic;
        //初始化一下UI按钮字典
        UIWindowsbuttons = new Dictionary<string, GameObject>();

        MergeWindows();
    }

    /// <summary>
    /// 将所有的窗口显示在这个栏的最上方 宽度排放整齐
    /// 高度为20
    /// </summary>
    private void MergeWindows()
    {
        int index = 0;
        //有一个窗口就创建一个按钮 同时这个块要挂载UIEventHandler 算了 暂时先用button吧

        foreach (var keys in UIwindowsDic.Keys)
        {
            GameObject uibut = Instantiate<GameObject>(MergeButton, transform);
            //生成对象并把他存到字典中
            UIWindowsbuttons.Add(keys, uibut);

            //再把按钮的文本的text改为keys
            uibut.GetComponentInChildren<Text>().text = keys;
            uibut.name = keys;
            uibut.GetComponent<UIEventHandler>().PointerClick += PointerClick;

            //然后再把按钮排在左上角
            uibut.GetComponent<RectTransform>().anchoredPosition = new Vector2(160 * index++, 0);
            
        }
    }

    private void PointerClick(PointerEventData eventData)
    {
        //把上一个关闭咯
        if(uiWindows != null) uiWindows.SetVisible(false);
        //把点击的那个掌管的那个窗口开开
        uiWindows = UIManger.Instance.UIwindowsdic[eventData.pointerClick.name];
        uiWindows.SetVisible(true);
    }



    //将窗口的显隐方法挂载到按钮上的方法
    
}
