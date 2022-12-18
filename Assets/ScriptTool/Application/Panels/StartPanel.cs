using System.Collections;
using System.Collections.Generic;
using UIFrameWork;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : BasePanel
{
    private static readonly string path = "Prefabs/Scenes/StartScenePanel";
    public StartPanel():base(new UIType(path))
    {
        
    }
    public override void OnEnter()
    {
        GameObject panel = UIManager.Instance.GetSingleUI(UIType);
        UITool.GetOrAddComponentInChildren<Button>("Btn_Setting", panel).onClick.AddListener(() =>
        {
            PanelManager.Instance.Push(new SettingPanel());
        });
        UITool.GetOrAddComponentInChildren<Button>("Btn_Play", panel).onClick.AddListener(() =>
        {
            SceneSystem.Instance.SetScene(new MainScene());
        });
        //Button btn_Audio = UITool.GetOrAddComponentInChildren<Button>("Btn_Audio", panel);
        //btn_Audio.onClick.AddListener(() =>
        //{
        //    Image imgOpen = btn_Audio.transform.Find("Icon1").GetComponent<Image>();
        //    Image imgClose = btn_Audio.transform.Find("Icon2").GetComponent<Image>();
        //    if(imgOpen.enabled)
        //    {
        //        imgOpen.enabled = false;
        //        imgClose.enabled = true;
        //    }
        //    else
        //    {
        //        imgOpen.enabled = true;
        //        imgClose.enabled = false;
        //    }
        //});
    }

}
