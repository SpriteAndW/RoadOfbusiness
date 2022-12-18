using System.Collections;
using System.Collections.Generic;
using UIFrameWork;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartScene : SceneBase
{
    private static readonly string sceneName = "Scenes/GameUI/StartScene";
    public override void OnEnter()
    {
        if(SceneManager.GetActiveScene().name!=sceneName)
        {
            SceneManager.LoadScene(sceneName);
            SceneManager.sceneLoaded += SceneLoaded;
        }
        else
        {
            PanelManager.Instance.Push(new StartPanel());
        }
    }

    public override void OnExit()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
        PanelManager.Instance.Clear();
    }

    private void SceneLoaded(Scene scene,LoadSceneMode mode)
    {
        PanelManager.Instance.Push(new StartPanel());
    }
}
