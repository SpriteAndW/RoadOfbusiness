using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneGuide : MonoSingleton<MainSceneGuide>
{
    public NoviceGuidePanel BankGuidePanel;
    public GameObject stepPrefab;

    [Header("各个场景切换按钮")] public RectTransform scene2;
    public RectTransform scene4;
    public RectTransform scene5;
    public RectTransform scene6;
    public RectTransform scene7;
    public RectTransform scene8;


    private void OnEnable()
    {
        EventHandler.ShowGuideOnSceneName += OnShowGuideOnSceneName;
    }

    private void OnDisable()
    {
        EventHandler.ShowGuideOnSceneName -= OnShowGuideOnSceneName;
    }

    
    
    private void OnShowGuideOnSceneName(string sceneName)
    {
        switch (sceneName)
        {
            case "Scene2":
                // DialogueManager.instance.isBankGuideing = true;
                InstantiateStep(scene2, sceneName);
                break;
            case "Scene4":
                InstantiateStep(scene4, sceneName);
                break;
            case "Scene5":
                InstantiateStep(scene5, sceneName);
                break;
            case "Scene6":
                InstantiateStep(scene6, sceneName);
                break;
            case "Scene7":
                InstantiateStep(scene7, sceneName);
                break;
            case "Scene8":
                InstantiateStep(scene8, sceneName);
                break;
        }
    }


    private void InstantiateStep(RectTransform sceneNametRectTransform, string sceneName)
    {
        var step = Instantiate(stepPrefab, BankGuidePanel.transform);
        step.GetComponent<Step>().target = sceneNametRectTransform;
        step.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "点击这里进入"+SwitchSceneName(sceneName);
        BankGuidePanel.ExcuteStep(0);
    }

    public void DestroyChildStep()
    {
        for (int i = 0; i < BankGuidePanel.gameObject.transform.childCount; i++)
        {
            Destroy(BankGuidePanel.gameObject.transform.GetChild(i));
        }
    }

    public string SwitchSceneName(string sceneName)
    {
        switch (sceneName)
        {
            case "Scene2":
                return SceneName.钱庄.ToString();

            case "Scene4":
                return SceneName.店铺.ToString();


            case "Scene5":
                return SceneName.交易所.ToString();


            case "Scene6":
                return SceneName.贸易路线.ToString();


            case "Scene7":
                return SceneName.会客厅.ToString();

            case "Scene8":
                return SceneName.商盟.ToString();

        }

        return null;
    }
}

public enum SceneName
{
    主场景,
    钱庄,
    店铺,
    交易所,
    贸易路线,
    会客厅,
    商盟,
}