using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SaveRecordDetail  //存款记录详情
{
    public int saveTime;
    public float saveMoney;
    public TradeTime saveType;
    public int takeTime;
    public float takeMoney;
    public float getMoney;
    public float finalGetMoney;
}

public class BankSaveRecordBtn : MonoBehaviour
{
    public SaveRecordDetail saveRecordDetail;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(UpdateRecordDetail);
    }



    /// <summary>
    /// 点击更新存款记录的详细信息
    /// </summary>
    private void UpdateRecordDetail()
    {
        EventHandler.CallUpdateBankSaveRecordUIEvent(saveRecordDetail);
    }
}