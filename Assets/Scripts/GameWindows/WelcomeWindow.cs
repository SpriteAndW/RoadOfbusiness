using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tool;

public class WelcomeWindow : MonoBehaviour
{
    //�ṩ���ַ�����Button����
    SaveDataWindow saveW;

    public void LoadSaveData()
    {
        //����Ӧ����Ҫ�򿪴��ڵ� ��ʱ������ֱ�Ӽ���
        saveW = UIManger.Instance.Getwindows<SaveDataWindow>();
        saveW.IsSave = false;
        saveW.SetVisible(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("�˳���Ϸ");
    }
}
