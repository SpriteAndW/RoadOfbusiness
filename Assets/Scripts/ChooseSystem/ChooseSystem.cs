using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSystem : MonoSingleton<ChooseSystem>
{
    //选择窗口的对象

    private ChooseWindow chooseW;
    /// <summary>
    /// 生成选项 对应事件
    /// </summary>
    /// 
    protected override void Init()
    {
        base.Init();

        //用UI管理器获取选择窗口的引用
        chooseW = UIManger.Instance.Getwindows<ChooseWindow>();
    }
    public void GenerateChoose(string[] eventName)
    {
        //List<IChoose> chose = new List<IChoose>();
        for (int i = 0; i < eventName.Length; i++)
        {
            //IChoose choose = ChooseFactory.CreateChoose(eventName[i]);
            //调用选择窗口的生成选择UI方法 把选择对象传过去
            //chose.Add(choose);
            eventName[i] += "Choose";
        }
        chooseW.GenerateChooseUI(eventName);
    }
}
