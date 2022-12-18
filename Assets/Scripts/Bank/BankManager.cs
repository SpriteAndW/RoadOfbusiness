using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CreditLevel  //信用等级
{
    低,
    一般,
    良好,
    优秀,
}



public class BankManager : MonoSingleton<BankManager>
{
    //public static BankManager instance; //单例

    [Header("人物信用等级属性:")] public CreditLevel creditLevel;

    [Header("信用减免比例")] public float interestRate = 1; //信用减免比例

    [Header("借款记录(需保存读取)")] public BorrowTradeDetail borrowTradeDetail = new BorrowTradeDetail();

    [Header("存款记录(需保存读取)")] public SaveRecordData_SO saveRecordDetailList;

    [Header("钱庄存款(需保存读取)")]public float saveMoney;
    
    
    

    //public static BankManager GetInstance()
    //{
    //    return instance;
    //}

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        if (instance != this)
    //        {
    //            GameObject.Destroy(gameObject);
    //        }
    //    }

    //}


    private void OnEnable()
    {
        EventHandler.UpdateBankSaveMoneyUIEvent += OnUpdateBankSaveMoneyUIEvent;
        EventHandler.UpdateBankBorrowEvent += OnUpdateBankBorrowEvent;
    }

    private void OnDisable()
    {
        EventHandler.UpdateBankSaveMoneyUIEvent -= OnUpdateBankSaveMoneyUIEvent;
        EventHandler.UpdateBankBorrowEvent -= OnUpdateBankBorrowEvent;
    }
    
    private void Start()
    {
        UpdateCreditLevel();
        EventHandler.CallUpdateBankUIEvent();
    }


    private void OnUpdateBankSaveMoneyUIEvent(SaveTradeDetail saveTradeDetail)
    {
        Business.Instance.wealth = saveTradeDetail.currentMoney;
        Debug.Log("财富变化(存款):" + -saveTradeDetail.currentMoney);

        Debug.Log("当前财富:" + Business.Instance.wealth);
        
        //刷新UI
        GameController.Instance.Refresh();
    }

    private void OnUpdateBankBorrowEvent(BorrowTradeDetail borrowTradeDetail)
    {
        Business.Instance.wealth += borrowTradeDetail.borrowMoney;
        Debug.Log("财富变化(借款):" + +borrowTradeDetail.borrowMoney);

        Debug.Log("当前财富:" + Business.Instance.wealth);
        
        //刷新UI
        GameController.Instance.Refresh();
    }

    
    

    /// <summary>
    /// 玩家财富变化
    /// </summary>
    /// <returns>财富变化值</returns>
    public float PlayerWealthChangeOnBank()
    {
        
        float getMoney = 0f;
        
        //存钱获得的利息
        if (saveRecordDetailList.savrRecordList.Count > 0)
        {
            foreach (var saveRecordDetail in saveRecordDetailList.savrRecordList)
            {
                //只有存款时间没有完成,才能获得利息
                if (saveRecordDetail.takeTime >= Business.Instance.playDays)
                {
                    Debug.Log("银行利息");
                    getMoney += GetBankSaveMoney(saveRecordDetail);
                }
            }
        }

        if (borrowTradeDetail.needBakeMoney>0)
        {
            //贷款减去的还款
            if (borrowTradeDetail.bakeTime > Business.Instance.playDays)
            {
                getMoney -= ReduceBankBorrowMoney(borrowTradeDetail);
            }
            else if (borrowTradeDetail.bakeTime == Business.Instance.playDays)
            {
                getMoney -= borrowTradeDetail.needBakeMoney;
                borrowTradeDetail.needBakeMoney = 0;
                borrowTradeDetail = new BorrowTradeDetail();
            }
        }
        Debug.Log("利息或还款:"+getMoney);

        //投资钱庄后每回合获得利息
        if (Business.Instance.isInvest)
        {
            getMoney += 20000;
        }
        return getMoney;
    }

    /// <summary>
    /// 根据存款记录详情返回每回合利息金额
    /// </summary>
    /// <param name="saveRecordDetail">存款记录详情</param>
    /// <returns>每回合利息</returns>
    private float GetBankSaveMoney(SaveRecordDetail saveRecordDetail)
    {
        return saveRecordDetail.getMoney * saveRecordDetail.saveMoney;
    }

    /// <summary>
    /// 根据贷款详情返回每回合还款金额
    /// </summary>
    /// <param name="borrowTradeDetail">贷款详情</param>
    /// <returns></returns>
    private float ReduceBankBorrowMoney(BorrowTradeDetail borrowTradeDetail)
    {
        //每还款一次,更新一次还需还款UI
        borrowTradeDetail.needBakeMoney -= borrowTradeDetail.bakeRate * borrowTradeDetail.finalBakeMoney;
        EventHandler.CallUpdateBorrowTradeDetailEvent(borrowTradeDetail);
        
        
        //借款比例*最总还钱*信用减免
        return borrowTradeDetail.bakeRate * borrowTradeDetail.finalBakeMoney * interestRate;
    }


    public SaveRecordDetail GetSaveRecordDetail(SaveTradeDetail saveTradeDetail)
    {
        SaveRecordDetail saveRecordDetail = new SaveRecordDetail();
        
        saveRecordDetail.saveTime = Business.Instance.playDays;
        saveRecordDetail.saveMoney = saveTradeDetail.saveMoney;
        saveRecordDetail.saveType = saveTradeDetail.tradeTime;
        saveRecordDetail.takeMoney = saveTradeDetail.saveMoney;
        saveRecordDetail.getMoney = saveTradeDetail.getMoneypercentage;

        switch (saveTradeDetail.tradeTime)
        {
            case TradeTime.三回合:
                saveRecordDetail.takeTime = Business.Instance.playDays + 30;
                saveRecordDetail.finalGetMoney = saveTradeDetail.saveMoney +
                                                 saveTradeDetail.getMoneypercentage * saveTradeDetail.saveMoney * 3;
                break;
            case TradeTime.五回合:
                saveRecordDetail.takeTime = Business.Instance.playDays + 50;
                saveRecordDetail.finalGetMoney = saveTradeDetail.saveMoney +
                                                 saveTradeDetail.getMoneypercentage * saveTradeDetail.saveMoney * 5;
                break;
            case TradeTime.七回合:
                saveRecordDetail.takeTime = Business.Instance.playDays + 70;
                saveRecordDetail.finalGetMoney = saveTradeDetail.saveMoney +
                                                 saveTradeDetail.getMoneypercentage * saveTradeDetail.saveMoney * 7;
                break;
        }
        
        //将存款记录传出,方便保存读取(完成)
        // BankManager.instance.saveRecordDetailList.Add(saveRecordDetail);
        return saveRecordDetail;
    }


    /// <summary>
    /// 根据信用值获取信用等级,可以在每次信用变化后调用一次
    /// </summary>
    public void UpdateCreditLevel()
    {
        if (Business.Instance.credit < 20 && Business.Instance.credit >= 0)
        {
            creditLevel = CreditLevel.低;
        }
        else if (Business.Instance.credit < 50)
        {
            creditLevel = CreditLevel.一般;
        }
        else if (Business.Instance.credit < 80)
        {
            creditLevel = CreditLevel.良好;
        }
        else
        {
            creditLevel = CreditLevel.优秀;
        }
    }

    /// <summary>
    /// 根据天数返回对应的天数文本内容
    /// </summary>
    /// <param name="day">天数</param>
    /// <returns></returns>
    public string GetTimeOnDay(int day)
    {
        return string.Format("{0}年--{1}季--{2}天",
            686 + day / 120, GetSeasonOnDay(day), 
            day % 30);
    }

    /// <summary>
    /// 根据天数返回季节
    /// </summary>
    /// <param name="day">天数</param>
    /// <returns></returns>
    private string GetSeasonOnDay(int day)
    {
        string season;
        switch (day % 120 / 30)
        {
            case 0:
                season = "春";
                break;
            case 1:
                season = "夏";
                break;
            case 2:
                season = "秋";
                break;
            case 3:
                season = "冬";
                break;
            default:
                season = "春";
                break;
        }

        return season;
    }
}