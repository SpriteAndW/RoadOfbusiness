using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tool;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class PlotWindow : UIWindows
{
    Text plotText;
    Button plotButton;
    bool isClick = false;
    GameObject character;
    //ChooseWindow chooseW;

    protected override void Awake()
    {
        base.Awake();
        plotText = GetComponentInChildren<Text>();
        plotButton = GetComponentInChildren<Button>();
        //把点击这个方法挂载到按钮上
        plotButton.onClick.AddListener(Isclick);
        //chooseW = UIManger.Instance.Getwindows<ChooseWindow>();
    }

    private void Isclick()
    {
        //如果点击 这个变成true
        isClick = true;
    }

    

    private bool IsClick()
    {
        //协程的泛型委托需要这种格式
        return isClick;
    }


    //提供通过一个列表生成一段剧情UI的方法
    public void GeneratePlot(List<string> plot)
    {
        //设置窗口可见
        SetVisible(true);
        StartCoroutine(Plot(plot));

    }
    public IEnumerator Plot(List<string> plot)
    {
        //在开始创建剧情的时候就生成文本框
        //文本框只有一个 生成一次即可
        //文本框需要挂载点击方法 可以用按钮
        for (int i = 0; i < plot.Count; i++)
        {
            isClick = false;
            //把列表的元素通过冒号拆开 然后元素0是预制件立绘的名字 元素1是text
            GeneratePlotUI(plot[i]);
            //点击后才循环生成UI 包括立绘图片和文本
            yield return new WaitUntil(IsClick);
            ObjectPool.Instance.CollectObject(character);
        }
        //剧情生成完毕将窗口设置隐藏
        SetVisible(false);
        MainWindow.Instance.Refresh();
    }



    private void GeneratePlotUI(string plot)
    {
        //把角色立绘创建出来并且调整好位置存到了对象池
        string[] aword = plot.Split(':');

        //如果是选择 则把后面的用逗号split
        if(aword[0] == "choose")
        {
            string[] choose = aword[1].Split(',');
            ChooseSystem.Instance.GenerateChoose(choose);
            isClick = true;
        }

        else
        {
            character = ObjectPool.Instance.CreateObject(aword[0],
            ResourcesManger.Load<GameObject>(aword[0]),
            new Vector2(960, 580), Quaternion.identity);
            character.transform.SetParent(transform);
            plotText.text = aword[1];
        }
        

    }
}
