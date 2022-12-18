using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using UnityEditor.UI;

public class BankBorrowDetailUI : MonoBehaviour
{
    [Header("对应文本组件获取")] 
    public TextMeshProUGUI borrowTimeText;
    public TextMeshProUGUI borrowMoneyText;
    public TextMeshProUGUI borrowTypeText;
    public TextMeshProUGUI borrowRateText;
    public TextMeshProUGUI bakeTimeText;
    public TextMeshProUGUI finalBakeMoneyText;


    /// <summary>
    /// 更新贷款详情UI
    /// </summary>
    /// <param name="borrowTradeDetail">贷款详情</param>
    public void GetBorrowTradeDeatil(BorrowTradeDetail borrowTradeDetail)
    {
        Debug.Log(borrowTradeDetail.borrowMoney);
        
        borrowTimeText.text = BankManager.Instance.GetTimeOnDay(Business.Instance.playDays);
        borrowMoneyText.text = borrowTradeDetail.borrowMoney.ToString();
        borrowTypeText.text = borrowTradeDetail.tradeTime.ToString();
        borrowRateText.text = "年化率为:" + borrowTradeDetail.borrowRate.ToString()+"每回合还:"+borrowTradeDetail.finalBakeMoney*borrowTradeDetail.bakeRate;
        bakeTimeText.text = BankManager.Instance.GetTimeOnDay(borrowTradeDetail.bakeTime);
        finalBakeMoneyText.text = borrowTradeDetail.finalBakeMoney.ToString();
    }



    /// <summary>
    /// 清空UI数据显示(待使用)
    /// </summary>
    public void EmptyRecordUI()
    {
        borrowTimeText.text = string.Empty;
        borrowMoneyText.text = string.Empty;
        borrowTypeText.text = string.Empty;
        borrowRateText.text = string.Empty;
        bakeTimeText.text = string.Empty;
        finalBakeMoneyText.text = string.Empty;
    }
}