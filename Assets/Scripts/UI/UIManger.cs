using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI管理器 用来控制窗口（即一个画布） 可是2D游戏的UI窗口用panel做就可以
/// 可以仿照做一个panel管理类
/// 用字典存储窗口
/// </summary>
/// 继承自单例
public class UIManger : MonoSingleton<UIManger>
{
    //存放窗口对象的字典
    public Dictionary<string, UIWindows> UIwindowsdic;

    protected override void Init()
    {
        //这是单例的初始化 执行一次父类的初始化 因为可能有一些都要完成的事
        //然后在单例创建时会执行这个方法 所以使用这个方法new一下字典
        base.Init();
        UIwindowsdic = new Dictionary<string, UIWindows>();
        //new完还要把场景中的窗口对象都加入到字典中
        //先把所有物体找着放在数组中
        FindWindows();
    }

    private void FindWindows()
    {
        UIWindows[] UIWindows = FindObjectsOfType<UIWindows>();
        for (int i = 0; i < UIWindows.Length; i++)
        {
            //如果里面没有这个窗口才添加
            if(!UIwindowsdic.ContainsKey(UIWindows[i].GetType().Name))
            {
                UIwindowsdic.Add(UIWindows[i].GetType().Name, UIWindows[i]);
                UIWindows[i].SetVisible(false);
            }

        }
    }
    //获取UIwindows的方法
    //限制T必须是UIwindows的子类
    public T Getwindows<T>() where T:UIWindows  
    {
        
        string key = typeof(T).Name;
        //如果字典中没有这个键 返回null
        if (!UIwindowsdic.ContainsKey(key))
        { FindWindows(); }
        if (!UIwindowsdic.ContainsKey(key)) return null;
        return UIwindowsdic[key] as T;
    }

    
    public T Getwindows<T>(string windowName) where T:UIWindows
    {
        if (!UIwindowsdic.ContainsKey(windowName))
            { FindWindows(); }
        return UIwindowsdic[windowName] as T;
    }





}
