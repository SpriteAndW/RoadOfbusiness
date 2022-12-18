using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankGuidTipPanel : NoviceGuideTipPanel
{
    public override void OnBtnSkipClick()
    {
        base.OnBtnSkipClick();
        PlayerPrefs.SetInt(Const.BankNovice, 1);
        Business.Instance.wealth -= 15000;
        //刷新UI
        GameController.Instance.Refresh();
    }

    public override void OnBtnEnterClick()
    {
        base.OnBtnEnterClick();
        // BankManager.Instance.isGuide = true;
        DialogueManager.instance.isBankGuideing = true;
    }
}