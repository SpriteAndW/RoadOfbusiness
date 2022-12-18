using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptionTipPanle : NoviceGuideTipPanel
{
    public override void OnBtnSkipClick()
    {
        base.OnBtnSkipClick();
        PlayerPrefs.SetInt(Const.ReceptionRoomNovice, 1);
    }

    public override void OnBtnEnterClick()
    {
        base.OnBtnEnterClick();
        // BankManager.Instance.isGuide = true;
        DialogueManager.instance.isReceptionGuideing = true;
    }
}
