using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UIFrameWork;
public class MainScene : SceneBase
{
    private static readonly string sceneName = "Scenes/GameUI/MainScene";
    public override void OnEnter()
    {
        if (SceneManager.GetActiveScene().name != sceneName)
        {
            SceneManager.LoadScene(sceneName);
            SceneManager.sceneLoaded += SceneLoaded;
        }
        else
        {
            PanelManager.Instance.Push(new MainPanel());
        }
    }

    public override void OnExit()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
        PanelManager.Instance.Clear();
    }

    private void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PanelManager.Instance.Push(new MainPanel());
    }
}
