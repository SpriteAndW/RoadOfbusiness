using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NoviceGuideTipPanel : MonoBehaviour
{
    public NoviceGuidePanel guidePanel;


    public virtual void OnBtnSkipClick()
    {
        // 修改数据
        // PlayerPrefs.SetInt(Const.BankNovice, 1);
        // 隐藏自己
        gameObject.SetActive(false);
    }

    public virtual void OnBtnEnterClick()
    {
        // 开始引导 执行第一步
        // BankManager.Instance.isGuide = true;
        guidePanel.ExcuteStep(0);
        gameObject.SetActive(false);
    }
}