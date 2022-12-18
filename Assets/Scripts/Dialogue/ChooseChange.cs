using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class ChooseChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [HideInInspector] public ChooseBtn changBtn;



    public void Change()
    {
        if (changBtn.chooseName != null)
        {
            switch (changBtn.BtnType)
            {
                case ChooseBtnType.simple:

                    // if (changBtn.WealthChange <= 0 && Business.Instance.wealth < -changBtn.WealthChange)
                    // {
                    //     return;
                    // }
                    // else
                    // {
                        Business.Instance.wealth += changBtn.WealthChange;
                    // }

                    // if (changBtn.CreditChange > 0)
                    // {
                        Business.Instance.credit += changBtn.CreditChange;
                    // }
                    // else if (changBtn.CreditChange <= 0 && Business.Instance.credit < -changBtn.CreditChange)
                    // {
                    //     return;
                    // }

                    if (changBtn.goods != null)
                    {
                        //InventoryWindow.Instance.myBag.itemList.Add(changBtn.goods);
                        changBtn.goods.AddItemHeld( changBtn.GoodsChange);
                    }

                    if (changBtn.dialogueID != 0)
                    {
                        Debug.Log(changBtn.dialogueID);
                        DialogueManager.instance.ShowDialogueOnDayID(changBtn.dialogueID);
                    }

                    break;
                case ChooseBtnType.guide:
                    EventHandler.CallShowGuideOnSceneName(changBtn.guideSceneName);
                    break;
                case ChooseBtnType.other:
                    //TODO:按钮选项添加
                    break;
            }
        }


        for (int i = 0; i < transform.parent.gameObject.transform.childCount; i++)
        {
            Destroy(transform.parent.gameObject.transform.GetChild(i).gameObject);
        }

        transform.parent.gameObject.SetActive(false);

        GameController.Instance.Refresh();
        
        SleepDialogueEvent.Instance.ChoosePlotDone();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        var tip = transform.GetChild(1).gameObject;
        tip.GetComponent<ChooseBtnDetialTip>().ShowChooseDetailTip(changBtn);
        tip.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        var tip = transform.GetChild(1).gameObject;
        tip.GetComponent<CanvasGroup>().DOFade(0, 0.5f);
        this.gameObject.transform.GetChild(2).GetComponent<Image>().DOFade(0,0.5f);
    }
}