using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class GameController : MonoSingleton<GameController>
{

    private MainWindow mainW;
    private MenuWindow menuW;
    public bool isFirstDelegate = true;
    protected override void Init()
    {
        base.Init();
        
        //不能在这生成剧情 很多都还没初始化
        //PlotSystem.Instance.GeneratePlot("begin.txt");
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="scene">场景 里面包含各种属性 name之类的</param>
    /// <param name="arg1"></param>
    private void PlotJudge(Scene scene, LoadSceneMode arg1)
    { 
        //在这里做各种判断来生成剧情 在加载场景的时候会调用这个方法
        //根据场景名字 财富值以及信用值等各种条件判断

        
        
        mainW.Refresh();
    }

    private void Start()
    {
        mainW = UIManger.Instance.Getwindows<MainWindow>();
        menuW = UIManger.Instance.Getwindows<MenuWindow>();
        SceneManager.sceneLoaded += PlotJudge;
        //生成剧情
        //PlotSystem.Instance.GeneratePlot("begin.txt");

        //测试选择农民职业按钮
        //ChooseSystem.Instance.GenerateChoose(new string[] { "FarmerVoc","BusiVoc"});
        //UIManger.Instance.Getwindows<MapWindows>().SetVisible(true);

    }

    public void Refresh()
    {
        mainW.Refresh();
    }
}