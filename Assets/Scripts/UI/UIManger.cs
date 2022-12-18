using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI������ �������ƴ��ڣ���һ�������� ����2D��Ϸ��UI������panel���Ϳ���
/// ���Է�����һ��panel������
/// ���ֵ�洢����
/// </summary>
/// �̳��Ե���
public class UIManger : MonoSingleton<UIManger>
{
    //��Ŵ��ڶ�����ֵ�
    public Dictionary<string, UIWindows> UIwindowsdic;

    protected override void Init()
    {
        //���ǵ����ĳ�ʼ�� ִ��һ�θ���ĳ�ʼ�� ��Ϊ������һЩ��Ҫ��ɵ���
        //Ȼ���ڵ�������ʱ��ִ��������� ����ʹ���������newһ���ֵ�
        base.Init();
        UIwindowsdic = new Dictionary<string, UIWindows>();
        //new�껹Ҫ�ѳ����еĴ��ڶ��󶼼��뵽�ֵ���
        //�Ȱ������������ŷ���������
        FindWindows();
    }

    private void FindWindows()
    {
        UIWindows[] UIWindows = FindObjectsOfType<UIWindows>();
        for (int i = 0; i < UIWindows.Length; i++)
        {
            //�������û��������ڲ����
            if(!UIwindowsdic.ContainsKey(UIWindows[i].GetType().Name))
            {
                UIwindowsdic.Add(UIWindows[i].GetType().Name, UIWindows[i]);
                UIWindows[i].SetVisible(false);
            }

        }
    }
    //��ȡUIwindows�ķ���
    //����T������UIwindows������
    public T Getwindows<T>() where T:UIWindows  
    {
        
        string key = typeof(T).Name;
        //����ֵ���û������� ����null
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
