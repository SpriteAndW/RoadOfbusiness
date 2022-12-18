using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tool;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class UIWindowsMerger : MonoSingleton<UIWindowsMerger>
{

    //UI���ںϲ��� ������UI���ڵ�����Ȩ����һ�������� ѡ���

    //�Ȼ�ȡ����UI���� ͨ��һ���ֵ�

    //��һ���洢UIwindowdic�ֵ�ĳ�Ա����
    Dictionary<string, UIWindows> UIwindowsDic;

    //��һ���洢UIwindow��ť���ֵ�
    Dictionary<string, GameObject> UIWindowsbuttons;

    //����һ���洢��ť����ĳ�Ա����
    GameObject MergeButton;

    //���Ǵ洢��һ���㿪�Ĵ��ڵĳ�Ա����
    UIWindows uiWindows;
    protected override void Init()
    {
        base.Init();
        //test
        print("nb");

        //��resourcesManger����һ�°�ť
        MergeButton = ResourcesManger.Load<GameObject>("MergeButton");

        //ͨ��UI�����������
        UIwindowsDic = UIManger.Instance.UIwindowsdic;
        //��ʼ��һ��UI��ť�ֵ�
        UIWindowsbuttons = new Dictionary<string, GameObject>();

        MergeWindows();
    }

    /// <summary>
    /// �����еĴ�����ʾ������������Ϸ� ����ŷ�����
    /// �߶�Ϊ20
    /// </summary>
    private void MergeWindows()
    {
        int index = 0;
        //��һ�����ھʹ���һ����ť ͬʱ�����Ҫ����UIEventHandler ���� ��ʱ����button��

        foreach (var keys in UIwindowsDic.Keys)
        {
            GameObject uibut = Instantiate<GameObject>(MergeButton, transform);
            //���ɶ��󲢰����浽�ֵ���
            UIWindowsbuttons.Add(keys, uibut);

            //�ٰѰ�ť���ı���text��Ϊkeys
            uibut.GetComponentInChildren<Text>().text = keys;
            uibut.name = keys;
            uibut.GetComponent<UIEventHandler>().PointerClick += PointerClick;

            //Ȼ���ٰѰ�ť�������Ͻ�
            uibut.GetComponent<RectTransform>().anchoredPosition = new Vector2(160 * index++, 0);
            
        }
    }

    private void PointerClick(PointerEventData eventData)
    {
        //����һ���رտ�
        if(uiWindows != null) uiWindows.SetVisible(false);
        //�ѵ�����Ǹ��ƹܵ��Ǹ����ڿ���
        uiWindows = UIManger.Instance.UIwindowsdic[eventData.pointerClick.name];
        uiWindows.SetVisible(true);
    }



    //�����ڵ������������ص���ť�ϵķ���
    
}
