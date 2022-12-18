using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopGuideTipPanle : NoviceGuideTipPanel
{
    public override void OnBtnSkipClick()
    {
        base.OnBtnSkipClick();
        PlayerPrefs.SetInt(Const.ShopNovice, 1);
    }

    public override void OnBtnEnterClick()
    {
        base.OnBtnEnterClick();
        // BankManager.Instance.isGuide = true;
        DialogueManager.instance.isShopGuideing = true;
    }
}
