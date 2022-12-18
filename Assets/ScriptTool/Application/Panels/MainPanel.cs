using System.Collections;
using System.Collections.Generic;
using UIFrameWork;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : BasePanel
{
    private static readonly string path = "Prefabs/Scenes/MainSecenPanel";
    public MainPanel() : base(new UIType(path))
    {

    }
    public override void OnEnter()
    {
        GameObject panel = UIManager.Instance.GetSingleUI(UIType);
        UITool.GetOrAddComponentInChildren<Button>("Btn_Exit", panel).onClick.AddListener(() =>
        {
            SceneSystem.Instance.SetScene(new StartScene());
        });
        UITool.GetOrAddComponentInChildren<Button>("Btn_Chat", panel).onClick.AddListener(() =>
        {
            PanelManager.Instance.Push(new CharacterPanel());
        });
    }
}
