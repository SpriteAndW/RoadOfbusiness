using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSystem : MonoSingleton<ChooseSystem>
{
    //ѡ�񴰿ڵĶ���

    private ChooseWindow chooseW;
    /// <summary>
    /// ����ѡ�� ��Ӧ�¼�
    /// </summary>
    /// 
    protected override void Init()
    {
        base.Init();

        //��UI��������ȡѡ�񴰿ڵ�����
        chooseW = UIManger.Instance.Getwindows<ChooseWindow>();
    }
    public void GenerateChoose(string[] eventName)
    {
        //List<IChoose> chose = new List<IChoose>();
        for (int i = 0; i < eventName.Length; i++)
        {
            //IChoose choose = ChooseFactory.CreateChoose(eventName[i]);
            //����ѡ�񴰿ڵ�����ѡ��UI���� ��ѡ����󴫹�ȥ
            //chose.Add(choose);
            eventName[i] += "Choose";
        }
        chooseW.GenerateChooseUI(eventName);
    }
}
