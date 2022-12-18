using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFrameWork;
using UnityEngine.UI;

public class CharacterPanel : BasePanel
{
    private static readonly string path = "Prefabs/Panels/CharacterPanel";
    public CharacterPanel() : base(new UIType(path))
    {

    }
    public override void OnEnter()
    {
        GameObject panel = UIManager.Instance.GetSingleUI(UIType);
        UITool.GetOrAddComponentInChildren<Button>("Btn_Close", panel).onClick.AddListener(() =>
         {
             PanelManager.Instance.Pop();
         });
    }
}
