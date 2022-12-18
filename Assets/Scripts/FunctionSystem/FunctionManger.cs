using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



/// <summary>
/// ���ܹ�����
/// ������  1���������Ҫ����ײ�� 2D.3D�Ķ�����
///        2���������Ҫ�����߼�� Ҫ����ײ����Ӧ
///        3���������Ҫ��UIEventHandler���
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

    //���ݵ������������ֵ���UI
    private void PushUIWindowByTargetName(PointerEventData eventData)
    {
        print(eventData.pointerClick.name);
        UIWindows ui = UIManger.Instance.Getwindows<UIWindows>
            (eventData.pointerClick.name + "Window");
        ui.SetVisible(true);
    }
}
