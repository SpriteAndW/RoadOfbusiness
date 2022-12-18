using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tool;

public class WelcomeWindow : MonoBehaviour
{
    //提供各种方法让Button挂载
    SaveDataWindow saveW;

    public void LoadSaveData()
    {
        //这里应该是要打开窗口的 暂时先试试直接加载
        saveW = UIManger.Instance.Getwindows<SaveDataWindow>();
        saveW.IsSave = false;
        saveW.SetVisible(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("退出游戏");
    }
}
