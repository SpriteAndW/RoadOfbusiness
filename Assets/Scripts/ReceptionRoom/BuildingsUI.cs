using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingsUI : MonoBehaviour
{
    [Header("组件获取")] public GameObject beforePanel;
    public GameObject afterPanel;
    public GameObject confirmPanel;

    [Header("组件获取")] public Text buildingName;
    public Text buildingNum;
    public Text buildingDescribe;
    public Text Tip;
    public Image buildingImage;

    public Sprite buildingOne;
    public Sprite buildingTwo;

    private int chooseType;
    public void OpenBuildingsPanel()
    {
        if(BuildingsManager.Instance.buildingType == 0 )
        {
            beforePanel.SetActive(true);
            afterPanel.SetActive(false);
        }
        else
        {
            afterPanel.SetActive(true);
            beforePanel.SetActive(false);
            OpenInformationPanel();
        }
    }

    public void OpenInformationPanel()
    {
        UpdateAfterPanel();
        
    }

    public void UpdateAfterPanel()
    {
        buildingNum.text = BuildingsManager.Instance.buildingNum.ToString();
        
        if (BuildingsManager.Instance.buildingType == 1)
        {
            buildingImage.sprite = buildingOne;
            buildingName.text = "孤儿院";
            buildingDescribe.text = "金钱换信用";

        }

        if (BuildingsManager.Instance.buildingType == 2)
        {
            buildingImage.sprite = buildingTwo;
            buildingName.text = "死士营";
            buildingDescribe.text = "信用换金钱";
        }
    }

    public void ChooseType()
    {
        BuildingsManager.Instance.buildingType = chooseType;
        if (BuildingsManager.Instance.buildingType == 1)
        {
            buildingName.text = "孤儿院";
            buildingDescribe.text = "金钱换信用";

        }

        if (BuildingsManager.Instance.buildingType == 2)
        {
            buildingName.text = "死士营";
            buildingDescribe.text = "信用换金钱";
        }
    }

    public void ChooseOrphanage()
    {
        chooseType = 1;
    }

    public void ChooseDeathCamp()
    {
        chooseType = 2;
    }

    public void ChooseBuildNew()
    {
        if(BuildingsManager.Instance.buildingNum!=5)
        {
            BuildingsManager.Instance.BuildNew();
            Tip.text = "加建成功";
        }
        else
        {
            Tip.text = "已达到建筑数量上限";
        }

        UpdateAfterPanel();
    }

    public void ChooseDismantleOld()
    {
        if(BuildingsManager.Instance.buildingNum!=0)
        {
            BuildingsManager.Instance.DismantleOld();
            Tip.text = "拆除成功";
        }
        else
        {
            Tip.text = "目前没有建筑物";
        }
        UpdateAfterPanel();
    }

}
