using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum TradeTime //贷款年份类型
{
    none,
    三回合,
    五回合,
    七回合,

}

[Serializable]
public class SaveTradeDetail //存款详情
{
    public float currentMoney; //玩家当前金额
    public float saveMoney; //存款金额
    public TradeTime tradeTime; //贷款年份:半年,一年,一年半
    public float getMoneypercentage; //获得利息百分比
}

[Serializable]
public class BorrowTradeDetail //贷款详情
{
    public float canBorrowMoney; //贷款额度(最大贷款金额)
    public float borrowMoney; //当前贷款
    public TradeTime tradeTime; //贷款年份:半年,一年,一年半
    public float bakeRate; //每回合总还款比例
    public int bakeTime; //还款完成时间
    public float borrowRate; //还款年化率
    public float finalBakeMoney; //总还款金额 
    public float needBakeMoney; //还需还款金额
}

public class TradeUI : MonoBehaviour
{
    [Header("组件获取")] public Slider slider;

    public TextMeshProUGUI currentMoneyText; // 第一行金钱文字

    public TMP_InputField inputField; //第二行金钱文字

    [Header("存储交易详细")] public SaveTradeDetail saveTradeDetail;

    [Header("贷款交易详细")] public BorrowTradeDetail borrowTradeDetail;


    /// <summary>
    /// 存款UI
    /// 更新Slider与金额对比SaveMoney数值
    /// </summary>
    public void UpdateSaveTradeUI()
    {
        saveTradeDetail.currentMoney = Business.Instance.wealth - Business.Instance.wealth * slider.value;
        saveTradeDetail.saveMoney = Business.Instance.wealth * slider.value;

        currentMoneyText.text = (saveTradeDetail.currentMoney).ToString();
        inputField.text = (saveTradeDetail.saveMoney).ToString();

        if (DialogueManager.instance.isBankGuideing)
        {
            NoviceGuidePanel._instance.NextStep(BankGuideConst.SaveNum);
        }
    }

    /// <summary>
    /// 贷款UI
    /// 更新Slider与金额对比borrowMoney数值
    /// </summary>
    public void UpdateBorrowTradeUI()
    {
        switch (BankManager.Instance.creditLevel)
        {
            case CreditLevel.低:
                borrowTradeDetail.canBorrowMoney = 0;
                break;
            case CreditLevel.一般:
                borrowTradeDetail.canBorrowMoney = 500000;
                borrowTradeDetail.borrowRate = 1.1f;
                break;
            case CreditLevel.良好:
                borrowTradeDetail.canBorrowMoney = 1000000;
                borrowTradeDetail.borrowRate = 1.07f;
                break;
            case CreditLevel.优秀:
                borrowTradeDetail.canBorrowMoney = 2000000;
                borrowTradeDetail.borrowRate = 1.05f;
                break;
        }

        borrowTradeDetail.borrowMoney = borrowTradeDetail.canBorrowMoney * slider.value;
        borrowTradeDetail.finalBakeMoney = borrowTradeDetail.borrowRate * borrowTradeDetail.borrowMoney;
        borrowTradeDetail.needBakeMoney = borrowTradeDetail.finalBakeMoney;


        currentMoneyText.text = (borrowTradeDetail.canBorrowMoney).ToString();
        inputField.text = (borrowTradeDetail.borrowMoney).ToString();


        if (DialogueManager.instance.isBankGuideing)
        {
            NoviceGuidePanel._instance.NextStep(BankGuideConst.BorrowNum);
        }
    }

    /// <summary>
    /// 选择存款贷款种类
    /// </summary>
    /// <param name="btnNum">对应的按钮</param>
    public void ChooseSaveTime(int btnNum)
    {
        switch (btnNum)
        {
            case 1: //半年按钮
                saveTradeDetail.tradeTime = TradeTime.三回合;
                borrowTradeDetail.tradeTime = TradeTime.三回合;
                borrowTradeDetail.bakeTime = Business.Instance.playDays + 30;
                borrowTradeDetail.bakeRate = 0.056f;
                break;
            case 2: //一年按钮
                saveTradeDetail.tradeTime = TradeTime.五回合;
                borrowTradeDetail.tradeTime = TradeTime.五回合;
                borrowTradeDetail.bakeTime = Business.Instance.playDays + 50;
                borrowTradeDetail.bakeRate = 0.0278f;
                break;
            case 3: //一年半按钮
                saveTradeDetail.tradeTime = TradeTime.七回合;
                borrowTradeDetail.tradeTime = TradeTime.七回合;
                borrowTradeDetail.bakeTime = Business.Instance.playDays + 70;
                borrowTradeDetail.bakeRate = 0.0185f;
                break;
        }

        if (DialogueManager.instance.isBankGuideing && borrowTradeDetail.borrowMoney != 0)
            NoviceGuidePanel._instance.NextStep(BankGuideConst.BorrowTime);
        else if (DialogueManager.instance.isBankGuideing && saveTradeDetail.saveMoney != 0)
            NoviceGuidePanel._instance.NextStep(BankGuideConst.SaveTime);
    }

    /// <summary>
    /// 存款确定与取消
    /// </summary>
    /// <param name="isSave">是否存款</param>
    public void SaveMoneyBtn(bool isSave)
    {
        Debug.Log(saveTradeDetail.saveMoney);
        Debug.Log(saveTradeDetail.tradeTime.ToString());
        if (isSave && saveTradeDetail.saveMoney > 0 && saveTradeDetail.tradeTime != TradeTime.none)
        {
            if (saveTradeDetail.saveMoney <= 1000000)
            {
                saveTradeDetail.getMoneypercentage = 0.003f;
            }
            else if (saveTradeDetail.saveMoney > 1000000 && saveTradeDetail.saveMoney <= 2000000 &&
                     saveTradeDetail.tradeTime != TradeTime.三回合)
            {
                saveTradeDetail.getMoneypercentage = 0.005f;
            }
            else if (saveTradeDetail.saveMoney > 2000000 && saveTradeDetail.tradeTime == TradeTime.七回合)
            {
                saveTradeDetail.getMoneypercentage = 0.01f;
            }
            else
            {
                saveTradeDetail.getMoneypercentage = 0.003f;
            }

            //呼叫事件: 更新BankUI(完成),更新玩家财富(完成)
            EventHandler.CallUpdateBankSaveMoneyUIEvent(saveTradeDetail);
            if (DialogueManager.instance.isBankGuideing)
            {
                NoviceGuidePanel._instance.NextStep(BankGuideConst.EnterSave);
            }
            
            //存款次数
            Business.Instance.saveMoneyNum++;
        }

        gameObject.SetActive(false);
    }

    /// <summary>
    /// 贷款确定与取消
    /// </summary>
    /// <param name="isBorrow">是否贷款</param>
    public void BorrowMoneyBtn(bool isBorrow)
    {
        if (isBorrow && borrowTradeDetail.borrowMoney > 0 && borrowTradeDetail.tradeTime != TradeTime.none)
        {
            //呼叫事件:玩家金币增加(完成),BankUI更新(完成),贷款详情更新(完成)
            EventHandler.CallUpdateBankBorrowEvent(borrowTradeDetail);
            BankManager.Instance.borrowTradeDetail = borrowTradeDetail;

            BankManager.Instance.interestRate = 1;

            if (DialogueManager.instance.isBankGuideing)
                NoviceGuidePanel._instance.NextStep(BankGuideConst.EntenBorrow);
        }
        else
        {
            borrowTradeDetail = new BorrowTradeDetail();
        }

        gameObject.SetActive(false);
    }
}