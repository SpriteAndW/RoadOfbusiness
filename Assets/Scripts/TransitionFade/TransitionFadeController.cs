using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionFadeController : MonoSingleton<TransitionFadeController>
{
    public Animator anim;

    // private void Awake()
    // {
    //     anim = transform.GetChild(0).GetComponent<Animator>();
    // }

    private void OnEnable()
    {
        EventHandler.AfterSceneLoadeEvent += OnAfterSceneLoadeEvent;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadeEvent -= OnAfterSceneLoadeEvent;
    }

    private void OnAfterSceneLoadeEvent(string sceneName)
    {
        Debug.Log(sceneName);

        StartCoroutine(LoadScene(sceneName));
        
        // Debug.Log(sceneName);
        // Debug.Log(sceneName == "MainScene" );
        // Debug.Log(SleepDialogueEvent.Instance.MainPlotIsDone(1001));
        // Debug.Log(PlayerPrefs.GetInt(Const.ShopNovice, 0) == 0);
        
     
    }

    private IEnumerator LoadScene(string sceneName)
    {
        anim.SetTrigger("FadeIn");

        yield return new WaitForSeconds(1f);
        var sceneLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        // Debug.Log(sceneName);
        anim.SetTrigger("FadeOut");

        yield return new WaitForSeconds(1.5f);
        
        if (sceneName == "MainScene" && SleepDialogueEvent.Instance.MainPlotIsDone(1001) &&
            PlayerPrefs.GetInt(Const.ShopNovice, 0) == 0)
        {
            EventHandler.CallShowGuideOnSceneName("Scene4");
        }

    }
}