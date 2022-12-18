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
        //�ѵ������������ص���ť��
        plotButton.onClick.AddListener(Isclick);
        //chooseW = UIManger.Instance.Getwindows<ChooseWindow>();
    }

    private void Isclick()
    {
        //������ ������true
        isClick = true;
    }

    

    private bool IsClick()
    {
        //Э�̵ķ���ί����Ҫ���ָ�ʽ
        return isClick;
    }


    //�ṩͨ��һ���б�����һ�ξ���UI�ķ���
    public void GeneratePlot(List<string> plot)
    {
        //���ô��ڿɼ�
        SetVisible(true);
        StartCoroutine(Plot(plot));

    }
    public IEnumerator Plot(List<string> plot)
    {
        //�ڿ�ʼ���������ʱ��������ı���
        //�ı���ֻ��һ�� ����һ�μ���
        //�ı�����Ҫ���ص������ �����ð�ť
        for (int i = 0; i < plot.Count; i++)
        {
            isClick = false;
            //���б��Ԫ��ͨ��ð�Ų� Ȼ��Ԫ��0��Ԥ�Ƽ���������� Ԫ��1��text
            GeneratePlotUI(plot[i]);
            //������ѭ������UI ��������ͼƬ���ı�
            yield return new WaitUntil(IsClick);
            ObjectPool.Instance.CollectObject(character);
        }
        //����������Ͻ�������������
        SetVisible(false);
        MainWindow.Instance.Refresh();
    }



    private void GeneratePlotUI(string plot)
    {
        //�ѽ�ɫ���洴���������ҵ�����λ�ô浽�˶����
        string[] aword = plot.Split(':');

        //�����ѡ�� ��Ѻ�����ö���split
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
