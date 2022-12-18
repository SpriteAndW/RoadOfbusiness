using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//===============加到GuideConst中==================
// /// <summary>
// /// 按钮对应跳转
// /// </summary>
// public class BankGuideConst
// {
//     public const string BeginBorrow = "BeginBorrow";
//     public const string BorrowNum = "BorrowNum";
//     public const string BorrowTime = "BorrowTime";
//     public const string EntenBorrow = "EntenBorrow";
//     
//     public const string ShowBorrowDetail = "ShowBorrowDetail";
//     public const string CloseBorrowDetail = "CloseBorrowDetail";
//     
//     public const string BeginSave = "BeginSave";
//     public const string SaveNum = "SaveNum";
//     public const string SaveTime = "SaveTime";
//     public const string EnterSave = "EnterSave";
//     
//     public const string ShowSaveDetail = "ShowSaveDetail";
//     public const string CloseSaveDetail = "CloseSaveDetail";
//
//
//
// }
// public class ShopGuideConst
// {
//     public const string OpenShop = "OpenShop";
//     public const string ChooseShopDetail = "ChooseShopDetail";
//     public const string CloseShopDetail = "CloseShopDetail";
//     public const string CloseShop = "CloseShop";
// }
//
// public class ReceptionRoomGuideConst
// {
//     public const string OpenMarry = "OpenMarry";
//     public const string ChooseGril = "ChooseGril";
//     public const string FindNew = "FindNew";
//     public const string CloseMarry = "CloseMarry";
//
// }
//
// public class Const
// {
//     public const string BankNovice = "BankNovice"; // 是不是新手的标志 
//     public const string ShopNovice = "ShopNovice";
//     public const string ReceptionRoomNovice = "ReceptionRoomNovice";
// }
////===============加到GuideConst中==================


public class NoviceGuidePanel : MonoBehaviour
{
    private GuideController guideController;

    private Step[] steps;

    private int currentStep;

    private Canvas canvas;

    public static NoviceGuidePanel _instance;

    private int tempStep;

    private bool isExcuting = false;

    public UnityEvent onFinshGuide;

    public bool isGuide;


    private void Awake()
    {
        _instance = this;
        guideController = transform.GetComponent<GuideController>();
        // 初始化所有的步骤
        InitSteps();

        canvas = transform.GetComponentInParent<Canvas>();
    }
    
    private void InitSteps()
    {
        steps = new Step[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            steps[i] = transform.GetChild(i).GetComponent<Step>();
        }
    }

    // 执行某一个步骤
    public void ExcuteStep(int step)
    {
        if (isExcuting)
        {
            return;
        }

        gameObject.SetActive(true);
        // 隐藏所有的步骤
        HideAllSteps();

        isExcuting = true;
        tempStep = step;
        //currentStep = step;
        if (step >= 0 && step < steps.Length)
        {
            //steps[step].Excute(guideController, canvas);
            Invoke("Excute", steps[step].delayTime);
        }
    }

    private void Excute()
    {
        currentStep = tempStep;

        steps[this.currentStep].Excute(guideController, canvas);

        isExcuting = false;
    }

    public void NextStep(string eventName)
    {
        if (eventName == steps[this.currentStep].EventName)
        {
            if (this.currentStep + 1 >= steps.Length)
            {
                // 把所有的步数都走完了
                gameObject.SetActive(false);
                DialogueManager.instance.isBankGuideing = false;
                DialogueManager.instance.isShopGuideing = false;
                DialogueManager.instance.isReceptionGuideing = false;
                onFinshGuide?.Invoke();
                return;
            }

            Hide();
            //this.currentStep++;
            ExcuteStep(this.currentStep + 1);
        }
    }

    // 隐藏所有的步骤
    private void HideAllSteps()
    {
        for (int i = 0; i < steps.Length; i++)
        {
            steps[i].gameObject.SetActive(false);
        }
    }

    public void Hide()
    {
        //base.Hide();
        guideController.Guide(canvas, null, GuideType.Rect);
    }


}