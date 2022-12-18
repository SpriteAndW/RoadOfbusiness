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
        
        //�����������ɾ��� �ܶ඼��û��ʼ��
        //PlotSystem.Instance.GeneratePlot("begin.txt");
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="scene">���� ��������������� name֮���</param>
    /// <param name="arg1"></param>
    private void PlotJudge(Scene scene, LoadSceneMode arg1)
    { 
        //�������������ж������ɾ��� �ڼ��س�����ʱ�������������
        //���ݳ������� �Ƹ�ֵ�Լ�����ֵ�ȸ��������ж�

        
        
        mainW.Refresh();
    }

    private void Start()
    {
        mainW = UIManger.Instance.Getwindows<MainWindow>();
        menuW = UIManger.Instance.Getwindows<MenuWindow>();
        SceneManager.sceneLoaded += PlotJudge;
        //���ɾ���
        //PlotSystem.Instance.GeneratePlot("begin.txt");

        //����ѡ��ũ��ְҵ��ť
        //ChooseSystem.Instance.GenerateChoose(new string[] { "FarmerVoc","BusiVoc"});
        //UIManger.Instance.Getwindows<MapWindows>().SetVisible(true);

    }

    public void Refresh()
    {
        mainW.Refresh();
    }
}