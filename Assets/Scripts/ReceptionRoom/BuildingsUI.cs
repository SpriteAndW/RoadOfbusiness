using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingsUI : MonoBehaviour
{
    [Header("�����ȡ")] public GameObject beforePanel;
    public GameObject afterPanel;
    public GameObject confirmPanel;

    [Header("�����ȡ")] public Text buildingName;
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
            buildingName.text = "�¶�Ժ";
            buildingDescribe.text = "��Ǯ������";

        }

        if (BuildingsManager.Instance.buildingType == 2)
        {
            buildingImage.sprite = buildingTwo;
            buildingName.text = "��ʿӪ";
            buildingDescribe.text = "���û���Ǯ";
        }
    }

    public void ChooseType()
    {
        BuildingsManager.Instance.buildingType = chooseType;
        if (BuildingsManager.Instance.buildingType == 1)
        {
            buildingName.text = "�¶�Ժ";
            buildingDescribe.text = "��Ǯ������";

        }

        if (BuildingsManager.Instance.buildingType == 2)
        {
            buildingName.text = "��ʿӪ";
            buildingDescribe.text = "���û���Ǯ";
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
            Tip.text = "�ӽ��ɹ�";
        }
        else
        {
            Tip.text = "�Ѵﵽ������������";
        }

        UpdateAfterPanel();
    }

    public void ChooseDismantleOld()
    {
        if(BuildingsManager.Instance.buildingNum!=0)
        {
            BuildingsManager.Instance.DismantleOld();
            Tip.text = "����ɹ�";
        }
        else
        {
            Tip.text = "Ŀǰû�н�����";
        }
        UpdateAfterPanel();
    }

}
