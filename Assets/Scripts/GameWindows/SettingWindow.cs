using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tool;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class SettingWindow : UIWindows
{
    public Slider totalVolume;
    public Slider bgVolume;
    public Slider effectVolume;

    public Button backBeginSceneBtn;
    public Button quitGameBtn;


    private float currentTotalVolume;
    private float currentbgVolume;
    private float currenteffectVolume;

    protected override void Awake()
    {
        base.Awake();
        
        totalVolume.onValueChanged.AddListener(AudioManager.Instance.SetMasterVolume);
        bgVolume.onValueChanged.AddListener(AudioManager.Instance.SetBGMusicVolume);
        effectVolume.onValueChanged.AddListener(AudioManager.Instance.SetEffectVolume);
        
        backBeginSceneBtn.onClick.AddListener(LoadSaveData);
        quitGameBtn.onClick.AddListener(QuitGame);
    }
    
    private void Start()
    {
        GetUIeventhandler("Close").PointerClick += SettingWindowClose;
    }
    
    private void SettingWindowClose(PointerEventData eventData)
    {
        SetVisible(false);
    }
    public void Refresh()
    {
        // AudioManager.Instance.audioMixer.GetFloat("MasterVolume",out currentTotalVolume);
        // AudioManager.Instance.audioMixer.GetFloat("BgMasterVolume",out currentbgVolume);
        // AudioManager.Instance.audioMixer.GetFloat("EffectVolume",out currenteffectVolume);
        //
        // Debug.Log(currentbgVolume);
        // totalVolume.value = currentTotalVolume;
        // bgVolume.value = currentbgVolume;
        // effectVolume.value = currenteffectVolume;
    }
    

    /// <summary>
    /// 返回BeginScene场景
    /// </summary>
    private void ReturnBeginScene()
    {
        SetVisible(false);
        EventHandler.CallAfterSceneLoadeEvent("BeginScene");
        Debug.Log("加载BeginScene场景");
    }
    
    
    SaveDataWindow saveW;
    /// <summary>
    /// 打开读取界面
    /// </summary>
    public void LoadSaveData()
    {
        //这里应该是要打开窗口的 暂时先试试直接加载
        saveW = UIManger.Instance.Getwindows<SaveDataWindow>();
        saveW.IsSave = false;
        saveW.SetVisible(true);
        
        SetVisible(false);
    }

    /// <summary>
    /// 退出游戏
    /// </summary>
    private void QuitGame()
    {
        Application.Quit();
        Debug.Log("退出游戏");
    }
    
}
